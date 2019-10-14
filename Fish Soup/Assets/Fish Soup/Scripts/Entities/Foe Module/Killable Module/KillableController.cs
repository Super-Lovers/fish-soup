public class KillableController : IKillableController
{
    private FoeEntityModel entity;
    private IDeathController deathController;

    public KillableController(
        FoeEntityModel entity)
    {
        this.entity = entity;
    }

    public void InflictDamage(int damage)
    {
        FoePropertiesController foeProperties = (FoePropertiesController)entity.GetProperties();
        IHealthController healthController = foeProperties.GetHealthController();

        bool validateBlow = ValidateDamage(healthController.GetHealth(), damage);

        if (validateBlow == true)
        {
            healthController.SetHealth(healthController.GetHealth() - damage);
            UnityEngine.Debug.Log(healthController.GetHealth() + " - " + damage + " = " + (healthController.GetHealth() - damage));
        }
        else
        {
            GetDeathController().Die(entity);
        }
    }

    public bool ValidateDamage(int health, int damage)
    {
        if (health > damage)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public IDeathController GetDeathController()
    {
        if (this.deathController == null)
        {
            DeathControllerFactory factory = new DeathControllerFactory();
            this.deathController = factory.Create();
        }
        return this.deathController;
    }
}
