using UnityEditor;

[CustomEditor(typeof(LevelGridView))]
public class LevelGridInspector : Editor
{
    private LevelGridView targetScript;

    private void OnEnable()
    {
        targetScript = (LevelGridView)target;
    }

    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox("In order to change these values, refer to \"Default Level Setting\" in the Config folder.", MessageType.Info);
        EditorGUILayout.LabelField("Biome: " + targetScript.levelSettings.biome, EditorStyles.boldLabel);

        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Grid Size: (" +
            "X: " + targetScript.levelSettings.gridSize.x + ", " +
            "Y: " + targetScript.levelSettings.gridSize.y + ", " +
            "Z: " + targetScript.levelSettings.gridSize.z + ")");

        EditorGUILayout.LabelField("Tile Size: (" +
            "X: " + targetScript.levelSettings.tileSize.x + ", " +
            "Y: " + targetScript.levelSettings.tileSize.y + ", " +
            "Z: " + targetScript.levelSettings.tileSize.z + ")");
    }
}
