using UnityEngine;

[CreateAssetMenu(fileName = "Game Settings Model", menuName = "Scriptable Objects/Game Settings Model", order = 1)]
public class GameSettingsModel : ScriptableObject
{
    /// <summary>
    /// Toggles whether or not the debug console and it's messages will be
    /// visualized in-game.
    /// </summary>
    public bool DebugMode = true;
}
