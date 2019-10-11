public abstract class FriendlyEntityModel : EntityModel
{
    [UnityEngine.SerializeField]
    private FriendlyPropertiesModel propertiesModel;
    private FriendlyPropertiesController propertiesController;

    public override object GetProperties()
    {
        return propertiesController;
    }
}