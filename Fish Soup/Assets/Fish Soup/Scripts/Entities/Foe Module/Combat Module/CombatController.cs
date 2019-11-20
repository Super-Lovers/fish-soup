using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CombatController : ICombatController
{
    private AbilitiesController abilitiesController = null;

    [SerializeField]
    private int damage = 0;

    /// <summary>
    /// The abilities listed here will be given to this entity's abilities controller.
    /// </summary>
    [SerializeField]
    private List<AbilityModel> abilities = new List<AbilityModel>();

    public void DamageEntity(FoeEntityModel entity)
    {
        entity.GetKillableController().InflictDamage(damage);
    }

    public int GetDamage()
    {
        return damage;
    }

    public void SetDamage(int damage)
    {
        this.damage = damage;
    }

    public AbilitiesController GetAbilitiesController()
    {
        // TODO: Homework on zeject component in local object hierarchy injection
        // Most likely temporary until I try to understand why
        // this can't work for me using ZenJect.
        if (abilitiesController == null)
        {
            abilitiesController = new AbilitiesController();
            abilitiesController.SetAbilities(abilities);
        }

        return abilitiesController;
    }
}