using UnityEngine;

public class PlayerController : FoeEntityModel
{
    private AbilitiesController abilitiesController = null;

    private void Start()
    {
        abilitiesController = propertiesController.GetCombatController().GetAbilitiesController();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            abilitiesController.Cast(
                abilitiesController.GetAbility(KeyCode.J, this), this);
        }
    }
}