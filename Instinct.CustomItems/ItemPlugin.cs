using Instinct.CustomItems.EventHandlers;
using InventorySystem;
using InventorySystem.Items.MicroHID.Modules;
using InventorySystem.Items.ThrowableProjectiles;
using LabApi.Events.CustomHandlers;
using LabApi.Features;
using LabApi.Loader.Features.Plugins;

namespace Instinct.CustomItems;

internal sealed class ItemPlugin : Plugin<Config> {
    public override string Name => "Instinct.CustomItems";
    public override string Description => "main lib for citems, idk";
    public override string Author => "wexels.dev";
    
    public override Version Version => new(1, 0, 0);
    public override Version RequiredApiVersion => LabApiProperties.CurrentVersion;
    
    public static ItemPlugin? Instance;
    
    private readonly CommonItemHandler _commonItemHandler = new();
    private readonly KeyCardItemHandler _keyCardItemHandler = new();
    private readonly NonItemRelatedHandler _nonItemRelatedHandler = new();
    private readonly UsableItemHandler _usableItemHandler = new();
    private readonly ThrowableItemHandler _throwableItemHandler = new();
    private readonly DamageHandler _damageHandler = new();
    private readonly FirearmHandler _firearmHandler = new();
    private readonly Scp914Handler _scp914Handler = new();
    private readonly JailbirdHandler _jailbirdHandler = new();
    private readonly RevolverHandler _revolverHandler = new();
    private readonly Scp127Handler _scp127Handler = new();
    private readonly CoinHandler _coinHandler = new();

    public override void Enable() {
        Instance = this;
        CustomHandlersManager.RegisterEventsHandler(this._commonItemHandler);
        CustomHandlersManager.RegisterEventsHandler(this._keyCardItemHandler);
        CustomHandlersManager.RegisterEventsHandler(this._nonItemRelatedHandler);
        CustomHandlersManager.RegisterEventsHandler(this._usableItemHandler);
        CustomHandlersManager.RegisterEventsHandler(this._throwableItemHandler);
        CustomHandlersManager.RegisterEventsHandler(this._damageHandler);
        CustomHandlersManager.RegisterEventsHandler(this._firearmHandler);
        CustomHandlersManager.RegisterEventsHandler(this._scp914Handler);
        CustomHandlersManager.RegisterEventsHandler(this._jailbirdHandler);
        CustomHandlersManager.RegisterEventsHandler(this._revolverHandler);
        CustomHandlersManager.RegisterEventsHandler(this._scp127Handler);
        CustomHandlersManager.RegisterEventsHandler(this._coinHandler);
        InventoryExtensions.OnItemRemoved += Subscribed.OnItemRemoved;
        ThrownProjectile.OnProjectileSpawned += Subscribed.ProjectileSpawned;
        CycleController.OnPhaseChanged += Subscribed.PhaseChanged;
        BrokenSyncModule.OnBroken += Subscribed.BrokenSyncModule_OnBroken;
        CustomItems.RegisterCustomItems();
    }

    public override void Disable() {
        CustomHandlersManager.UnregisterEventsHandler(this._commonItemHandler);
        CustomHandlersManager.UnregisterEventsHandler(this._keyCardItemHandler);
        CustomHandlersManager.UnregisterEventsHandler(this._nonItemRelatedHandler);
        CustomHandlersManager.UnregisterEventsHandler(this._usableItemHandler);
        CustomHandlersManager.UnregisterEventsHandler(this._throwableItemHandler);
        CustomHandlersManager.UnregisterEventsHandler(this._damageHandler);
        CustomHandlersManager.UnregisterEventsHandler(this._firearmHandler);
        CustomHandlersManager.UnregisterEventsHandler(this._scp914Handler);
        CustomHandlersManager.UnregisterEventsHandler(this._jailbirdHandler);
        CustomHandlersManager.UnregisterEventsHandler(this._revolverHandler);
        CustomHandlersManager.UnregisterEventsHandler(this._scp127Handler);
        CustomHandlersManager.UnregisterEventsHandler(this._coinHandler);
        InventoryExtensions.OnItemRemoved -= Subscribed.OnItemRemoved;
        ThrownProjectile.OnProjectileSpawned -= Subscribed.ProjectileSpawned;
        CycleController.OnPhaseChanged -= Subscribed.PhaseChanged;
        BrokenSyncModule.OnBroken -= Subscribed.BrokenSyncModule_OnBroken;
        CustomItems.UnRegisterAllCustomItems();
    }
}