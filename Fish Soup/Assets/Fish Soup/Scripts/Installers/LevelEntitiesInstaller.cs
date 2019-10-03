using Zenject;

public class LevelEntitiesInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IProperties>().To<Properties>().AsSingle();
        Container.Bind<IStateMachine>().To<StateMachine>().AsSingle();
    }
}