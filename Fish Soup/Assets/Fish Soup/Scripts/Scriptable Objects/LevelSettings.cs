using UnityEngine;

[CreateAssetMenu(fileName = "LevelSettings", menuName = "Scriptable Objects/Level Settings", order = 1)]
public class LevelSettings : ScriptableObject
{
    public Vector3 gridSize = Vector3.zero;
    public Vector3 tileSize = Vector3.zero;
}
