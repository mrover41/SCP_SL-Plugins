using System.Collections.Concurrent;
using Instinct.Core.Interfaces;
using MEC;
using Microsoft.EntityFrameworkCore;

namespace Instinct.Core.Features {
    public class DataStorage<T> : IDisposable where T : class, IDataEntity, new() {
        private readonly string _connectionString;
        private readonly string _tableName;
        
        private readonly ConcurrentDictionary<string, T> _cache = new();
        private readonly ConcurrentDictionary<string, byte> _dirtyEntries = new();

        private readonly CoroutineHandle _saveCoroutine;
        private bool _isDisposed;

        public DataStorage(string connectionString, string? tableName = null) {
            this._connectionString = connectionString;
            this._tableName = tableName ?? typeof(T).Name;

            this.InitializeAndLoad();
            
            this._saveCoroutine = Timing.RunCoroutine(this.AutoSaveCoroutine());
        }

        private void InitializeAndLoad() {
            try {
                using GenericDbContext<T> db = new(this._connectionString, this._tableName);
                db.Database.EnsureCreated();

                foreach (T? entity in db.DataSet) {
                    this._cache.TryAdd(entity.Id, entity);
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"[DataStorage] Init Error: {ex}");
            }
        }

        public bool Contains(string id) {
            return this._cache.ContainsKey(id);
        }

        public T? Get(string id) {
            return this._cache.TryGetValue(id, out T? val) ? val : null;
        }

        public T GetOrCreate(string id) {
            return this._cache.GetOrAdd(id, _ => new T { Id = id });
        }

        public void Update(T data) {
            this._cache[data.Id] = data;
            this.MarkDirty(data.Id);
        }

        public void Modify(string id, Action<T> action) {
            T data = this.GetOrCreate(id);
            action(data);
            this.MarkDirty(id);
        }

        public void Delete(string id) {
            if (!this._cache.TryRemove(id, out _)) return;
            this._dirtyEntries.TryRemove(id, out byte _);

            Task.Run(async () => {
                await using GenericDbContext<T> db = new(this._connectionString, this._tableName);
                T stub = new() { Id = id };
                db.DataSet.Remove(stub);
                await db.SaveChangesAsync();
            });
        }

        public IEnumerable<T> GetAll() {
            return this._cache.Values;
        }

        private void MarkDirty(string id) {
            this._dirtyEntries.TryAdd(id, 0);
        }

        private IEnumerator<float> AutoSaveCoroutine() {
            while (!this._isDisposed) {
                yield return Timing.WaitForSeconds(10f);
                
                this.SaveAsync().Wait(); 
            }
        }

        private async Task SaveAsync() {
            if (this._dirtyEntries.IsEmpty) return;

            List<string> dirtyIds = this._dirtyEntries.Keys.ToList();
            this._dirtyEntries.Clear();

            try {
                await using GenericDbContext<T> db = new(this._connectionString, this._tableName);
                List<string>? existingIds = await db.DataSet
                    .Where(x => dirtyIds.Contains(x.Id))
                    .Select(x => x.Id)
                    .ToListAsync();

                foreach (string? id in dirtyIds) {
                    if (!this._cache.TryGetValue(id, out T? cachedObj)) continue;

                    if (existingIds.Contains(id)) {
                        db.DataSet.Attach(cachedObj);
                        db.Entry(cachedObj).State = EntityState.Modified;
                    }
                    else {
                        db.DataSet.Add(cachedObj);
                    }
                }

                await db.SaveChangesAsync();
            }
            catch (Exception ex) {
                Console.WriteLine($"[DataStorage] Save Failed: {ex.Message}");
                foreach (string? id in dirtyIds) this._dirtyEntries.TryAdd(id, 0);
            }
        }

        public void Dispose() {
            this._isDisposed = true;
            Timing.KillCoroutines(this._saveCoroutine);
            this.SaveAsync().Wait();
        }
    }

    public class GenericDbContext<T>(string connectionString, string tableName) : DbContext where T : class, IDataEntity {
        public DbSet<T> DataSet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(connectionString); 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<T>(entity => {
                entity.HasKey(e => e.Id);
                entity.ToTable(tableName);
                entity.Property(e => e.Id).HasMaxLength(64);
            });
        }
    }
}