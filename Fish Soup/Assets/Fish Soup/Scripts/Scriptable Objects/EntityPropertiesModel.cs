using UnityEngine;

[CreateAssetMenu(fileName = "EntityPropertiesModel", menuName = "Scriptable Objects/Entity Properties Model", order = 1)]
public class EntityPropertiesModel : ScriptableObject
{
    public string label = string.Empty;
    public int health = 0;
}
