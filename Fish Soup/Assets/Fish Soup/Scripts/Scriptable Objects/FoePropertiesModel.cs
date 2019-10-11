using UnityEngine;

[CreateAssetMenu(fileName = "Foe Properties Model", menuName = "Scriptable Objects/Foe Properties Model", order = 1)]
public class FoePropertiesModel : ScriptableObject
{
    public string label = string.Empty;
    public HealthController healthController;
    public CombatController combatController;
}
