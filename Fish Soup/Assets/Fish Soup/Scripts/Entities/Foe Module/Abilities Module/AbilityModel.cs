using UnityEngine;

[CreateAssetMenu(fileName = "Ability Name", menuName = "Abiliy Template")]
public class AbilityModel : ScriptableObject
{
    [SerializeField] private string entityName = string.Empty;
    [SerializeField] private string abilityName = string.Empty;
    [Space(10)]
    [SerializeField] private bool isCastable = false;

    /// <summary>
    /// [Optional] An animation that will be played when the ability is casted. Animations must NOT loop.
    /// </summary>
    [SerializeField] private string animationName = string.Empty;

    /// <summary>
    /// [Optional] Particles that will be instantiated when the ability is casted. Optional.
    /// </summary>
    [SerializeField] private GameObject particles = null;

    public string GetAbilityName()
    {
        return abilityName;
    }
}