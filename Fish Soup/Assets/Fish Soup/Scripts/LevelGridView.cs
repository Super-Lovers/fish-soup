using UnityEngine;

public class LevelGridView : MonoBehaviour
{
    public static LevelGridView Instance = null;

    // Grid parameters
    public LevelSettingsModel levelSettings = null;

    // Level parameters
    public LevelContainerController levelContainer = null;

    public static LevelGridView GetInstance()
    {
        return (Instance ?? (Instance = GameObject.FindObjectOfType<LevelGridView>()));
    }

    public void DrawGrid()
    {
        float currentX = 0;
        float currentY = 0;
        float currentZ = 0;

        for (int i = 0; i < levelSettings.gridSize.x; i++)
        {
            for (int j = 0; j < levelSettings.gridSize.z; j++)
            {
                for (int k = 0; k < levelSettings.gridSize.y; k++)
                {
                    Gizmos.DrawWireCube(
                        new Vector3(
                            currentX,
                            currentY,
                            currentZ),
                        levelSettings.tileSize);

                    currentY += levelSettings.tileSize.y;
                }

                currentY = 0;
                currentZ += levelSettings.tileSize.z;
            }

            currentZ = 0;
            currentX += levelSettings.tileSize.x;
        }
    }

    public Vector3 SnapToGridCoordinates(Vector3 pos)
    {
        Vector3 newPoint = new Vector3(
            levelSettings.tileSize.x * Mathf.Round(pos.x / levelSettings.tileSize.x),
            levelSettings.tileSize.y * Mathf.Round(pos.y / levelSettings.tileSize.y),
            levelSettings.tileSize.z * Mathf.Round(pos.z / levelSettings.tileSize.z)
            );

        return newPoint;
    }

    public bool IsInBoundaries(Vector3 pos)
    {
        if ((pos.x >= 0 && pos.x <= levelSettings.gridSize.x * levelSettings.tileSize.x) &&
            (pos.y >= 0 && pos.y <= levelSettings.gridSize.y * levelSettings.tileSize.y) &&
            (pos.z >= 0 && pos.z <= levelSettings.gridSize.z * levelSettings.tileSize.z))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1f, 1f, 1f, 0.1f);
        DrawGrid();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        DrawGrid();
    }
}
