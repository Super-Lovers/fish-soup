[System.Serializable]
public class PropertiesModel : IProperties
{
    [UnityEngine.SerializeField] private string label = string.Empty;
    [UnityEngine.SerializeField] private int health = 0;

    public PropertiesModel(EntityPropertiesModel model)
    {
        label = model.label;
        health = model.health;
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int health)
    {
        this.health = health;
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