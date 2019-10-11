using Zenject;

public abstract class FoeEntityModel : EntityModel
{
    private FriendlyEntityModel player;

    public FoePropertiesController propertiesController;
    [UnityEngine.SerializeField]
    private FoePropertiesModel propertiesModel;
    private IStateMachine stateMachine;
    private IKillableController killableController;

    [Inject]
    private void Construct(
        IStateMachine stateMachine,
        IKillableController killableController,
        FriendlyEntityModel player)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.killableController = killableController;
    }

    public IStateMachine GetStateMachine()
    {
        return this.stateMachine;
    }

    public IKillableController GetKillableController()
    {
        return this.killableController;
    }

    public override object GetProperties()
    {
        return propertiesController;
    }
}