public interface IStateMachine
{
    State GetState();
    void SetState(State state);
}