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
        Debug.LogFormat("Started casting {0} by {1}.", ability.GetAbilityName(), entity.GetProperties().GetLabel());
        Debug.LogFormat("Casting {0} by {1}...", ability.GetAbilityName(), entity.GetProperties().GetLabel());
        Debug.LogFormat("Completed casting {0} by {1}.", ability.GetAbilityName(), entity.GetProperties().GetLabel());

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
}