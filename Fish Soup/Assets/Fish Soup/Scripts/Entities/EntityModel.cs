using UnityEngine;
using Zenject;

public class EntityModel : MonoBehaviour
{
    private IStateMachine stateMachine = null;
    private IProperties properties = null;

    [Inject]
    private void Construct(
        IProperties properties,
        IStateMachine stateMachine)
    {
        this.properties = properties;
        this.stateMachine = stateMachine;
    }
}
