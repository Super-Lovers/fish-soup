using UnityEngine;
using Zenject;

public class Entity : MonoBehaviour
{
    private IStateMachine stateMachine = null;
    private IProperties properties = null;

    private void Start()
    {
        Debug.Log(properties.GetLabel());
        Debug.Log(stateMachine.GetState());
    }

    [Inject]
    private void Construct(
        IProperties properties,
        IStateMachine stateMachine)
    {
        this.properties = properties;
        this.stateMachine = stateMachine;
    }
}
