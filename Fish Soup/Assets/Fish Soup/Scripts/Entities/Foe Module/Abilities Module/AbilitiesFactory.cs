using UnityEngine;

public class AbilitiesFactory
{
    private AbilitiesFactory Instance = new AbilitiesFactory();

    public AbilitiesFactory()
    {
        if (Instance != null && Instance != this)
        {
            Instance = this;
        }
    }

    /// <summary>
    /// Creates an Ability instance with the given name, animation and particles parameters extracted from the Resources folder.
    /// </summary>
    public AbilityModel Create(
        string entityName,
        string abilityName)
    {
        AbilityModel ability = null;

        if (abilityName != string.Empty)
        {
            ability = Resources.Load<GameObject>(
                string.Format("Entities/Ability Animations/{0}/{1}", entityName, abilityName))
                .GetComponent<AbilityModel>();
        }

        if (ability == null)
        {
            throw new System.Exception(string.Format("The ability named {0} could not be found in the given path \"Resources/Abilities/{1}/{2}\". Please validate whether or not this ability prefab exists!", abilityName, entityName, abilityName));
        }

        return ability;
    }
}