public class DeathController : IDeathController
{
    public void Die(FoeEntityModel entity)
    {
        FoePropertiesController foeProperties = (FoePropertiesController)entity.GetProperties();

        LogController.LogMessage(foeProperties.GetLabel() + " has fallen!");
    }
}