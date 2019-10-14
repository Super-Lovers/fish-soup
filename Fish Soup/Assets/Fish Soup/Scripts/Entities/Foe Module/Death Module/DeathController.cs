public class DeathController : IDeathController
{
    public void Die(FoeEntityModel entity)
    {
        FoePropertiesController foeProperties = (FoePropertiesController)entity.GetProperties();

        UnityEngine.Debug.Log(foeProperties.GetLabel() + " has fallen!");
    }
}