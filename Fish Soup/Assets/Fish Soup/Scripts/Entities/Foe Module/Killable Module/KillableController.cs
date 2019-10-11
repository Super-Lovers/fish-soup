public class KillableController : IKillableController
{
    private FoeEntityModel entity;
    private IDeathController deathController;

    public KillableController(FoeEntityModel entity, IDeathController deathController)
    {
        this.deathController = deathController;
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
        }
        else
        {
            deathController.Die(entity);
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
}
