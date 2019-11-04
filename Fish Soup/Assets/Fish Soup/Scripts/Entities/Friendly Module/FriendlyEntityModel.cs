public abstract class FriendlyEntityModel : EntityModel
{
    [UnityEngine.SerializeField]
    private PropertiesModel propertiesModel = null;
    private FriendlyPropertiesController propertiesController = null;

    public override IProperties GetProperties()
    {
        if (propertiesController == null)
        {
            FriendlyPropertiesFactory factory = new FriendlyPropertiesFactory();
            this.propertiesController = factory.Create(this.propertiesModel);
        }
        return this.propertiesController;
    }
}