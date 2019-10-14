public class FoePropertiesFactory : PropertiesFactory
{
    public override FoePropertiesController Create(
        PropertiesModel properties,
        CombatController combatController)
    {
        return new FoePropertiesController(
            properties,
            combatController);
    }
}