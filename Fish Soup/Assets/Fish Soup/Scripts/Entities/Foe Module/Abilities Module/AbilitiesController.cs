using System.Collections.Generic;
using UnityEngine;

public class AbilitiesController
{
    private List<AbilityModel> abilities = new List<AbilityModel>();

    private EntityHUDModel entityHUDModel = null;
    private AbilitySlotModel abilitySlot = null;

    private void Start()
    {
        entityHUDModel = GameObject.FindObjectOfType<EntityHUDModel>();
    }

    public AbilitiesController(List<AbilityModel> abilities)
    {
        this.abilities = abilities;
    }

    /// <summary>
    ///  Cast the given ability based on the entity model given. Entity model is necessary because you might have two abilities with the same name but different mechanics/entites it is based on.
    /// </summary>
    public bool Cast(AbilityModel ability, EntityModel entity)
    {
        if (entityHUDModel == null)
        {
            entityHUDModel = GameObject.FindObjectOfType<EntityHUDModel>();
        }

        if (abilitySlot != null && abilitySlot.GetCooldown() > 0)
        {
            LogController.LogMessage(string.Format(
                "Cannot cast <color=blue>{0}</color> because it is in cooldown for <color=teal>{1}</color> more seconds.",
                ability.GetAbilityName(),
                abilitySlot.GetCooldown()
                ));

            return false;
        }

        if (ability.GetCastable() == true)
        {
            LogController.LogMessage(string.Format(
                "Started casting <color=blue>{0}</color> by <color=teal>{1}</color>.",
                ability.GetAbilityName(),
                entity.GetProperties().GetLabel()
                ));
            LogController.LogMessage(string.Format(
                "Casting <color=blue>{0}</color> by <color=teal>{1}</color>...",
                ability.GetAbilityName(),
                entity.GetProperties().GetLabel()
                ));
            LogController.LogMessage(string.Format(
                "Completed casting <color=blue>{0}</color> by <color=teal>{1}</color>.",
                ability.GetAbilityName(),
                entity.GetProperties().GetLabel()
                ));
        }
        else
        {
            LogController.LogMessage(string.Format(
                "Completed casting <color=blue>{0}</color> by <color=teal>{1}</color>.",
                ability.GetAbilityName(),
                entity.GetProperties().GetLabel()
                ));
        }

        GameObject.Instantiate(ability.GetParticles(), entity.transform.position, Quaternion.identity);

        if (entityHUDModel.GetEntity() == entity)
        {
            AbilitySlotModel[] slots = entityHUDModel.GetAbilitiesContainer().GetComponentsInChildren<AbilitySlotModel>();

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].GetAbilityName() == ability.GetAbilityName())
                {
                    abilitySlot = slots[i];
                    slots[i].Cooldown(ability.GetCooldown());
                    break;
                }
            }
        }

        return true;
    }

    public void SetAbilities(List<AbilityModel> abilities)
    {
        this.abilities = abilities;
    }

    public List<AbilityModel> GetAbilities()
    {
        return abilities;
    }

    public AbilityModel GetAbility(KeyCode keycode, EntityModel entity)
    {
        foreach (AbilityModel ability in abilities)
        {
            if (ability.GetKey() == keycode)
            {
                return ability;
            }
        }

        throw new System.Exception(
            string.Format("An ability with the key {0} was not found in {1}'s abilities list!",
            keycode, entity.GetProperties().GetLabel()
            ));
    }
}