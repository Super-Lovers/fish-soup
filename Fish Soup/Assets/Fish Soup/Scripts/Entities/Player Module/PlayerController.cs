using UnityEngine;

public class PlayerController : FoeEntityModel
{
    private AbilitiesController abilitiesController = null;
    private IStateMachine stateMachine = null;

    [SerializeField]
    private State currentState = State.Idling;

    private void Start()
    {
        abilitiesController = propertiesController.GetCombatController().GetAbilitiesController();
        stateMachine = GetStateMachine();
    }

    private void Update()
    {
        // Idle state guard
        if (Input.anyKeyDown == false)
        {
            stateMachine.SetState(State.Idling);
            return;
        }

        // Movement keys
        if (Input.GetKeyDown(KeyCode.W) ||
            Input.GetKeyDown(KeyCode.S) ||
            Input.GetKeyDown(KeyCode.A) ||
            Input.GetKeyDown(KeyCode.D) ||
            Input.GetKeyDown(KeyCode.LeftArrow) ||
            Input.GetKeyDown(KeyCode.RightArrow) ||
            Input.GetKeyDown(KeyCode.UpArrow) ||
            Input.GetKeyDown(KeyCode.DownArrow))
        {
            stateMachine.SetState(State.Moving);
            abilitiesController.Cast(
                abilitiesController.GetAbility(KeyCode.J, this), this);
        }

        currentState = stateMachine.GetState();
    }
}