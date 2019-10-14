public class FriendlyPropertiesController : IProperties
{
    [UnityEngine.SerializeField]
    private string label = string.Empty;

    // Dependancies
    private IHealthController healthController;

    public FriendlyPropertiesController(PropertiesModel properties)
    {
        this.label = properties.label;
        this.healthController = properties.healthController;
    }

    public FriendlyPropertiesController() { }

    public IHealthController GetHealthController()
    {
        return this.healthController;
    }

    public string GetLabel()
    {
        return label;
    }

    public void SetLabel(string label)
    {
        this.label = label;
    }

    public ICombatController GetCombatController()
    {
        throw new System.NotImplementedException();
    }
}