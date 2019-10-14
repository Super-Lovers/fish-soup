public abstract class PropertiesFactory
{
    public virtual FriendlyPropertiesController Create(
        PropertiesModel properties)
    {
        throw new System.NotImplementedException();
    }

    public virtual FoePropertiesController Create(
        PropertiesModel properties,
        CombatController combatController)
    {
        throw new System.NotImplementedException();
    }
}