using Zenject;
using UnityEngine;

public abstract class EntityModel : MonoBehaviour
{
    private IStateMachine stateMachine = null;

    [SerializeField]
    private EntityPropertiesModel entityPropertiesModel = null;
    private PropertiesModel properties = null;

    [Inject]
    private void Construct(
        IStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
        properties = new PropertiesModel(entityPropertiesModel);
    }

    public IStateMachine GetStateMachine()
    {
        return stateMachine;
    }

    public PropertiesModel GetProperties()
    {
        return properties;
    }
}
