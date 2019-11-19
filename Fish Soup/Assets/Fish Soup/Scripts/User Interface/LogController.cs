using UnityEngine;

public class LogController : MonoBehaviour
{
    [Tooltip("All game settings configurations are located in the \"Fish Soup/Config\" folder")]
    [SerializeField] private GameSettingsModel gameSettingsModel = null;

    /// <summary>
    /// Settings configuration extracted from a non-serializable Game 
    /// Settings Model in order to have one as a field for readability.
    /// </summary>
    private static GameSettingsModel gameSettingsConfig = null;

    private void Awake()
    {
        gameSettingsConfig = new GameSettingsModel();
        gameSettingsConfig.DebugMode = gameSettingsModel.DebugMode;

        Toggle(gameSettingsConfig.DebugMode);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Semicolon))
        {
            gameSettingsConfig.DebugMode = !gameSettingsConfig.DebugMode;
            Toggle(gameSettingsConfig.DebugMode);
        }
    }

    public static void LogMessage(string message)
    {
        if (gameSettingsConfig.DebugMode == true)
        {
            Debug.Log(message);
        }
    }

    /// <summary>
    /// Toggles the debugging interface depending on the parameter given.
    /// </summary>
    private void Toggle(bool value)
    {
        gameSettingsConfig.DebugMode = value;
        transform.GetChild(0).gameObject.SetActive(value);
    }
}
