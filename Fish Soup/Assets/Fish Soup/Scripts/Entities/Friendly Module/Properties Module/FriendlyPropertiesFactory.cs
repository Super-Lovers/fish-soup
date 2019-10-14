public class FriendlyPropertiesFactory : PropertiesFactory
{
    public override FriendlyPropertiesController Create(
        PropertiesModel properties)
    {
        return new FriendlyPropertiesController(properties);
    }
}