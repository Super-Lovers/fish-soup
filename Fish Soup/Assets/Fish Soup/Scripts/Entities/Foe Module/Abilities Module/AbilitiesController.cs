using System.Collections.Generic;
using UnityEngine;

public class AbilitiesController
{
    private List<AbilityModel> abilities = new List<AbilityModel>();

    /// <summary>
    ///  Cast the given ability based on the entity model given. Entity model is necessary because you might have two abilities with the same name but different mechanics/entites it is based on.
    /// </summary>
    public bool Cast(AbilityModel ability, EntityModel entity)
    {
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