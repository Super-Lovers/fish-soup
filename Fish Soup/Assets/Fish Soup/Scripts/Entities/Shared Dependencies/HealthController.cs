[System.Serializable]
public class HealthController : IHealthController
{
    [UnityEngine.SerializeField] private int health = 0;
    [UnityEngine.SerializeField] private int maxHealth = 0;

    public HealthController(int health, int maxHealth)
    {
        this.health = health;
        this.maxHealth = maxHealth;
    }

    public int GetHealth()
    {
        return health;
    }

    public void SetHealth(int health)
    {
        this.health = health;
    }
}
