using Zenject;

public class LevelEntitiesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IProperties>().To<PropertiesModel>().AsSingle();
        Container.Bind<IStateMachine>().To<StateMachineController>().AsSingle();
    }
}