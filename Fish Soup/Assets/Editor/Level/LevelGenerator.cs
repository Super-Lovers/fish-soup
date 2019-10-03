using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class LevelGenerator
{
    private static LevelGrid levelGrid = null;
    private static Dictionary<string, List<GameObject>> biomeLibraries = new Dictionary<string, List<GameObject>>();

    private static Transform oceanFloorContainer = null;

    [MenuItem("Level Generator/Generate Level")]
    public static void GenerateGrid()
    {
        LoadBiomeLibraries();

        levelGrid =
            GameObject.FindObjectOfType<LevelGrid>();

        ClearLevel();
        if (levelGrid.levelContainer == null)
        {
            levelGrid.levelContainer = new LevelContainer();
        }
        string[,,] grid = levelGrid.levelContainer.GetGridArray();

        SetupLevel();

        Vector3 positionOfTile = new Vector3(0, 0, 0);
        int i = 0;
        int j = 0;
        int k = 0;

        for (i = 0; i < grid.GetLength(0); i++)
        {
            InstantiateTile(grid[i, 0, 0], positionOfTile);
            for (j = 0; j < grid.GetLength(1); j++)
            {
                InstantiateTile(grid[i, j, 0], positionOfTile);
                for (k = 0; k < grid.GetLength(2); k++)
                {
                    positionOfTile.y += levelGrid.levelSettings.tileSize.y;
                }

                positionOfTile.y = 0;
                positionOfTile.z += levelGrid.levelSettings.tileSize.z;
            }

            positionOfTile.z = 0;
            positionOfTile.x += levelGrid.levelSettings.tileSize.x;
        }
    }

    private static void SetupLevel()
    {
        int i = 0;
        int j = 0;
        //int k = 0;

        for (i = 0; i < levelGrid.levelContainer.GetGridArray().GetLength(0); i++)
        {
            levelGrid.levelContainer.GetGridArray()[i, 0, 0] = "Ocean Floor";

            for (j = 0; j < levelGrid.levelContainer.GetGridArray().GetLength(1); j++)
            {
                levelGrid.levelContainer.GetGridArray()[i, j, 0] = "Ocean Floor";
            }
        }
    }

    /// <summary>
    /// Collects all biomes and their corresponding tiles from the Resources folder and stores them in the biomesLibrary variable.
    /// </summary>
    private static void LoadBiomeLibraries()
    {
        if (biomeLibraries.Count > 0)
        {
            biomeLibraries.Clear();
        }

        string[] numberOfEnums = System.Enum.GetNames(typeof(Biome));
        foreach (string biome in numberOfEnums)
        {
            if (biomeLibraries.ContainsKey(biome) == false)
            {
                KeyValuePair<string, List<GameObject>> newLibrary = new KeyValuePair<string, List<GameObject>>();

                Object[] prefabs = Resources.LoadAll("Biomes/" + biome);
                List<GameObject> prefabGameObjects = new List<GameObject>();
                foreach(Object obj in prefabs)
                {
                    prefabGameObjects.Add((GameObject)obj);
                }

                newLibrary = new KeyValuePair<string, List<GameObject>>(biome, prefabGameObjects);
                biomeLibraries.Add(newLibrary.Key, newLibrary.Value);
            }
        }
    }

    /// <summary>
    /// Instantiates a tile based on the current biome of the level settings and its corresponding tile in its collection of tiles gathered from the Resources biome folder.
    /// </summary>
    /// <param name="biome"></param>
    /// <param name="tile"></param>
    /// <returns></returns>
    private static void InstantiateTile(string tile, Vector3 position)
    {
        if (tile == string.Empty || tile == null)
        {
            return;
        }

        string currentBiome = levelGrid.levelSettings.biome.ToString();
        string tileAssetName = tile;

        GameObject tileObj = null;
        foreach (KeyValuePair<string, List<GameObject>> library in biomeLibraries)
        {
            if (library.Key == currentBiome)
            {
                foreach (GameObject obj in library.Value)
                {
                    if (obj.name == tileAssetName)
                    {
                        tileObj = obj;
                        break;
                    }
                }
            }
        }

        // Might not be permanent, but I am leaving it for now for
        // the sake of clarity at the start of the project hierarchy.
        if (oceanFloorContainer == null)
        {
            oceanFloorContainer = new GameObject(tileAssetName + "s").transform;
            oceanFloorContainer.transform.SetParent(levelGrid.transform);
        }

        if (tileObj != null)
        {
            tileObj = GameObject.Instantiate(tileObj, GameObject.Find(tileAssetName + "s").transform);

            tileObj.transform.position = position;
        }
    }

    private static void ClearLevel()
    {
        // We start from 1 because we want to avoid deleting the camera container.
        List<GameObject> children = new List<GameObject>();
        for (int i = 1; i < levelGrid.transform.childCount; i++)
        {
            children.Add(levelGrid.transform.GetChild(i).gameObject);
        }

        foreach (GameObject obj in children)
        {
            GameObject.DestroyImmediate(obj);
        }
    }
}
