using Zenject;
using UnityEngine;

public class LevelEntitiesInstaller : MonoInstaller
{
    public PlayerController playerEntity;
    public GameObject sharkEntity;

    public override void InstallBindings()
    {
        Container.BindInstance(playerEntity).AsSingle();
        Container.Bind<SharkFactory>().AsSingle();
        Container.BindFactory<SharkEntity, SharkEntity.Factory>().FromComponentInNewPrefab(sharkEntity);
        Container.Bind<IStateMachine>().To<StateMachineController>().AsSingle();
        Container.Bind<ICombatController>().To<CombatController>();
    }
}