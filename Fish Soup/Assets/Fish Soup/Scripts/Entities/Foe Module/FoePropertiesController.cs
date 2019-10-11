public class FoePropertiesController : IProperties
{
    [UnityEngine.SerializeField]
    private string label = string.Empty;

    // Dependancies
    private IHealthController healthController;
    private ICombatController combatController;

    public FoePropertiesController(FoePropertiesModel properties, CombatController combatController)
    {
        this.label = properties.label;
        this.healthController = properties.healthController;
        this.combatController = combatController;
    }

    public IHealthController GetHealthController()
    {
        return this.healthController;
    }

    public ICombatController GetCombatController()
    {
        return this.combatController;
    }

    public string GetLabel()
    {
        return label;
    }

    public void SetLabel(string label)
    {
        this.label = label;
    }
}