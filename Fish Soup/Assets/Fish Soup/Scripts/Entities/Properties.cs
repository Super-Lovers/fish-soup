public class Properties : IProperties
{
    private string label = string.Empty;
    private int health = 100;

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