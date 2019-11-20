using UnityEngine;

[CreateAssetMenu(fileName = "Ability Name", menuName = "Abiliy Template")]
public class AbilityModel : ScriptableObject
{
    [SerializeField] private Sprite abilityPortrait = null;
    [SerializeField] private string abilityName = string.Empty;
    [TextArea(1, 3)]
    [SerializeField] private string abilityDescription = string.Empty;

    [Space(10)]
    [SerializeField] private bool isCastable = false;
    [SerializeField] private KeyCode castKey = KeyCode.None;

    /// <summary>
    /// [Optional] An animation that will be played when the ability is casted. Animations must NOT loop.
    /// </summary>
    [Space(10)]
    [SerializeField] private string animationName = string.Empty;

    /// <summary>
    /// [Optional] Particles that will be instantiated when the ability is casted. Optional.
    /// </summary>
    [SerializeField] private GameObject particles = null;

    public string GetAbilityName()
    {
        return abilityName;
    }

    public string GetAbilityDescription()
    {
        return abilityDescription;
    }

    public Sprite GetAbilityPortrait()
    {
        return abilityPortrait;
    }

    public bool GetCastable()
    {
        return isCastable;
    }

    public GameObject GetParticles()
    {
        return particles;
    }

    public KeyCode GetKey()
    {
        return castKey;
    }
}