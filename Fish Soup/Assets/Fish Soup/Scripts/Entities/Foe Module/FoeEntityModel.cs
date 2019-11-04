using Zenject;

public abstract class FoeEntityModel : EntityModel
{
    private PlayerController player = null;

    public FoePropertiesController propertiesController = null;
    [UnityEngine.SerializeField]
    private FoePropertiesModel propertiesModel = null;
    private IStateMachine stateMachine = null;
    private IKillableController killableController = null;

    [Inject]
    private void Construct(
        IStateMachine stateMachine,
        PlayerController player)
    {
        PropertiesFactory factory = new FoePropertiesFactory();
        this.player = player;
        this.stateMachine = stateMachine;
        this.propertiesController = factory.Create(propertiesModel, propertiesModel.combatController);
    }

    public IStateMachine GetStateMachine()
    {
        return this.stateMachine;
    }

    public IKillableController GetKillableController()
    {
        if (killableController == null)
        {
            KillableControllerFactory factory = new KillableControllerFactory();
            this.killableController = factory.Create(this);
        }
        return this.killableController;
    }

    public override IProperties GetProperties()
    {
        return propertiesController;
    }
}