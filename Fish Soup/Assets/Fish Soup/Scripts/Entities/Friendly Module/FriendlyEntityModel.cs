public abstract class FriendlyEntityModel : EntityModel
{
    [UnityEngine.SerializeField]
    private PropertiesModel propertiesModel;
    private FriendlyPropertiesController propertiesController;

    public override object GetProperties()
    {
        return propertiesController;
    }
}