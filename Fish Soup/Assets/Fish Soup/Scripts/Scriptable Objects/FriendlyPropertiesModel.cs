using UnityEngine;

[CreateAssetMenu(fileName = "Friendly Properties Model", menuName = "Scriptable Objects/Friendly Properties Model", order = 1)]
public class FriendlyPropertiesModel : ScriptableObject
{
    public string label = string.Empty;
    public HealthController healthController;
}
