using UnityEngine;
using UnityEditor;

public class LevelGenerator
{
    [MenuItem("World Generator/Generate Level")]
    public static void GenerateGrid()
    {
        LevelGrid levelGrid =
            GameObject.FindGameObjectWithTag("Level")
            .GetComponent<LevelGrid>();

        float currentX = 0;
        float currentY = 0;
        float currentZ = 0;

        for (int i = 0; i < levelGrid.levelSettings.gridSize.x; i++)
        {
            for (int j = 0; j < levelGrid.levelSettings.gridSize.z; j++)
            {
                for (int k = 0; k < levelGrid.levelSettings.gridSize.y; k++)
                {
                    // TODO: Complete generator test tiles

                    currentY += levelGrid.levelSettings.tileSize.y;
                }

                currentY = 0;
                currentZ += levelGrid.levelSettings.tileSize.z;
            }

            currentZ = 0;
            currentX += levelGrid.levelSettings.tileSize.x;
        }
    }
}
