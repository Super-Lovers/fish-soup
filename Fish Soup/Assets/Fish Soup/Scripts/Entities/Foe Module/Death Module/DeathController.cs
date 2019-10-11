public class DeathController : IDeathController
{
    public void Die(EntityModel entity)
    {
        FoeEntityModel foe = (FoeEntityModel)entity;
        FoePropertiesController foeProperties = (FoePropertiesController)foe.GetProperties();
        if (foe)
        {
            UnityEngine.Debug.Log(foeProperties.GetLabel() + " has fallen!");
        }
    }
}