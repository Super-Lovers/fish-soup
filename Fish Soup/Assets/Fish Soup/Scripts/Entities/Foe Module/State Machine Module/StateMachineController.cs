[System.Serializable]
public class StateMachineController : IStateMachine
{
    private State state = State.Idling;

    public State GetState()
    {
        return state;
    }

    public void SetState(State state)
    {
        this.state = state;
    }
}