using Zenject;
using UnityEngine;

public class LevelEntitiesInstaller : MonoInstaller
{
    public PlayerController playerEntity;
    public GameObject sharkEntity;

    public override void InstallBindings()
    {
        Container.BindInstance(playerEntity).AsSingle().NonLazy();

        // Foe Modules injection
        Container.Bind<IKillableController>().To<KillableController>().AsTransient();
        Container.Bind<IStateMachine>().To<StateMachineController>().AsTransient();
        Container.Bind<ICombatController>().To<CombatController>().AsTransient();

        // Friendly Module Injection
        Container.Bind<FriendlyPropertiesController>().ToSelf().AsTransient();

        // Factories
        Container.Bind<SharkFactory>().AsSingle();
        Container.BindFactory<SharkEntity, SharkEntity.Factory>().FromComponentInNewPrefab(sharkEntity);
    }
}