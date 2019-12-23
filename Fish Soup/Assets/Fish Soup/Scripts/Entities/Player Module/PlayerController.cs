using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FoeEntityModel
{
    private AbilitiesController abilitiesController = null;
    private IStateMachine stateMachine = null;

    [SerializeField]
    private State currentState = State.Idling;

    // Unity-component dependancies
    private Animator animator = null;
    private int lastKeyPressed = 1;
    private List<int> lastKeysPressed = new List<int>();

    private void Start()
    {
        abilitiesController = propertiesController.GetCombatController().GetAbilitiesController();
        stateMachine = GetStateMachine();

        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        stateMachine.SetState(State.Idling);

        // Temporary
        // Movement keys
        if (Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S) ||
            Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.LeftArrow) ||
            Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.UpArrow) ||
            Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("IsIdle", false);
            //    lastKeysPressed.Add(lastKeyPressed);

            //    if (Input.GetKeyDown(KeyCode.W) ||
            //        Input.GetKeyDown(KeyCode.UpArrow))
            //    {
            //        lastKeyPressed = 3;
            //    }
            //    if ((Input.GetKeyDown(KeyCode.W) ||
            //        Input.GetKeyDown(KeyCode.UpArrow)) &&
            //        lastKeysPressed[lastKeysPressed.Count - 1] == 4)
            //    {
            //        lastKeyPressed = 5;
            //        return;
            //    }
            //    if ((Input.GetKeyDown(KeyCode.W) ||
            //        Input.GetKeyDown(KeyCode.UpArrow)) &&
            //        lastKeysPressed[lastKeysPressed.Count - 1] == 2)
            //    {
            //        lastKeyPressed = 6;
            //        return;
            //    }


            //    if (Input.GetKeyDown(KeyCode.S) ||
            //        Input.GetKeyDown(KeyCode.DownArrow))
            //    {
            //        lastKeyPressed = 1;
            //    }
            //    if ((Input.GetKeyDown(KeyCode.S) ||
            //        Input.GetKeyDown(KeyCode.DownArrow)) &&
            //        lastKeysPressed[lastKeysPressed.Count - 1] == 4)
            //    {
            //        lastKeyPressed = 8;
            //        return;
            //    }
            //    if ((Input.GetKeyDown(KeyCode.S) ||
            //        Input.GetKeyDown(KeyCode.DownArrow)) &&
            //        lastKeysPressed[lastKeysPressed.Count - 1] == 2)
            //    {
            //        lastKeyPressed = 7;
            //        return;
            //    }


            //    if (Input.GetKeyDown(KeyCode.A) ||
            //        Input.GetKeyDown(KeyCode.LeftArrow))
            //    {
            //        lastKeyPressed = 4;
            //    }
            //    if ((Input.GetKeyDown(KeyCode.A) ||
            //        Input.GetKeyDown(KeyCode.LeftArrow)) &&
            //        lastKeysPressed[lastKeysPressed.Count - 1] == 3)
            //    {
            //        lastKeyPressed = 8;
            //        return;
            //    }
            //    if ((Input.GetKeyDown(KeyCode.A) ||
            //        Input.GetKeyDown(KeyCode.LeftArrow)) &&
            //        lastKeysPressed[lastKeysPressed.Count - 1] == 1)
            //    {
            //        lastKeyPressed = 5;
            //        return;
            //    }


            //    if (Input.GetKeyDown(KeyCode.D) ||
            //        Input.GetKeyDown(KeyCode.RightArrow))
            //    {
            //        lastKeyPressed = 2;
            //    }
            //    if ((Input.GetKeyDown(KeyCode.D) ||
            //        Input.GetKeyDown(KeyCode.RightArrow)) &&
            //        lastKeysPressed[lastKeysPressed.Count - 1] == 3)
            //    {
            //        lastKeyPressed = 7;
            //        return;
            //    }
            //    if ((Input.GetKeyDown(KeyCode.D) ||
            //        Input.GetKeyDown(KeyCode.RightArrow)) &&
            //        lastKeysPressed[lastKeysPressed.Count - 1] == 1)
            //    {
            //        lastKeyPressed = 6;
            //        return;
            //    }

            stateMachine.SetState(State.Moving);
            //animator.SetInteger("LastKeyPressedIndex", lastKeyPressed);
        }
        else
        {
            animator.SetBool("IsIdle", true);
        }

        // Ability slot cast keys
        if (Input.GetKey(KeyCode.J))
        {
            try
            {
                abilitiesController.Cast(abilitiesController.GetAbility(KeyCode.J, this), this);
            }
            catch (System.Exception)
            {
                LogController.LogMessage(string.Format(
                    "The ability binded to key {0} for the player does not exist! Make sure it is in the Player Model Ability Slots and that the ability exists!",
                    KeyCode.J
                    ));
            }
        }
        else if (Input.GetKey(KeyCode.K))
        {
            try
            {
                abilitiesController.Cast(abilitiesController.GetAbility(KeyCode.K, this), this);
            }
            catch (System.Exception)
            {
                LogController.LogMessage(string.Format(
                    "The ability binded to key {0} for the player does not exist! Make sure it is in the Player Model Ability Slots and that the ability exists!",
                    KeyCode.K
                    ));
            }
        }
        else if (Input.GetKey(KeyCode.L))
        {
            try
            {
                abilitiesController.Cast(abilitiesController.GetAbility(KeyCode.L, this), this);
            }
            catch (System.Exception)
            {
                LogController.LogMessage(string.Format(
                    "The ability binded to key {0} for the player does not exist! Make sure it is in the Player Model Ability Slots and that the ability exists!",
                    KeyCode.L
                    ));
            }
        }

        currentState = stateMachine.GetState();
    }
}