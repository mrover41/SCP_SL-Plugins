using Corwarx_Project.Enums;
using LabApi.API.Features;
using LabApi.Events.EventArgs.Player;
using UnityEngine;

namespace Corwarx_Project.Features.Components.SCP049Components {
    public class SCP049Component : MonoBehaviour {
        Player Player { get; set; }
        private SCP049Stats _stats = SCP049Stats.None;
        public SCP049Stats Stats { 
            get {
                return _stats;
            } 

            set {
                ChangeState(value, _stats);
                _stats = value;
            } 
        }

        void Start() {
            LabApi.Events.Handlers.Player.Hurting += OnDamage;
            Player = Player.Get(gameObject);
            Logger.Debug($"SCP049Component started for {Player.Nickname} ({Player.UserId})");
        }

        void OnDestroy() {
            LabApi.Events.Handlers.Player.Hurting -= OnDamage;
            Logger.Debug($"SCP049Component destroyed for {Player.Nickname} ({Player.UserId})");
        }

        void ChangeState(SCP049Stats newStat, SCP049Stats oldStat) {
            switch (oldStat) {
                case SCP049Stats.Cuffed: Player.RemoveHandcuffs(); break;
            }

            switch (newStat) {
                case SCP049Stats.Cuffed: Player.Handcuff(); break;
            }
            Logger.Debug($"SCP049Component: {Player.Nickname} ({Player.UserId}) changed state from {oldStat} to {newStat}");
        }

        private void OnDamage(HurtingEventArgs ev) {
            if (ev.Attacker != Player) return;
            if (_stats == SCP049Stats.Cuffed) ev.IsAllowed = false;
            Logger.Debug($"SCP049Component: {Player.Nickname} ({Player.UserId}) is being hurt by {ev.Attacker.Nickname} ({ev.Attacker.UserId}) with damage {ev.Amount}");
        }
    }
}
