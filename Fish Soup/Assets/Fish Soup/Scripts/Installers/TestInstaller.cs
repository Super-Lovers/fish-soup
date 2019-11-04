using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "TestInstaller", menuName = "Installers/TestInstaller")]
public class TestInstaller : ScriptableObjectInstaller<TestInstaller>
{
    [SerializeField]
    public PlayerController playerEntity;
    [SerializeField]
    public GameObject sharkEntity;
    [SerializeField]
    public GameObject NPCEntity;

    public override void InstallBindings()
    {
        Container.BindInstance(playerEntity).AsSingle().NonLazy();

        // Foe Modules injection
        Container.Bind<IKillableController>().To<KillableController>().AsTransient();
        Container.Bind<IStateMachine>().To<StateMachineController>().AsTransient();
        Container.Bind<ICombatController>().To<CombatController>().AsTransient();

        // Friendly Module Injection
        Container.Bind<FriendlyPropertiesController>().ToSelf().AsTransient();

        // Shared gameObject modules
        //Container.Bind<Animator>().FromComponentInChildren();
        //Container.Bind<AbilitiesController>().ToSelf().AsTransient();

        // Factories
        Container.Bind<SharkFactory>().AsSingle();
        Container.BindFactory<SharkEntity, SharkEntity.Factory>().FromComponentInNewPrefab(sharkEntity);
    }
}