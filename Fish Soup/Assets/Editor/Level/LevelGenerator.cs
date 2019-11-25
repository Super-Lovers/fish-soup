using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class LevelGenerator
{
    private static GameObject levelPrefab = null;
    private static LevelGridView levelGrid = null;
    private static Dictionary<string, List<GameObject>> biomeLibraries = new Dictionary<string, List<GameObject>>();
    private static List<GameObject> propsLibrary = new List<GameObject>();

    private static int initialChildCount = 0;
    private static Transform oceanFloorContainer = null;
    private static Transform waterContainer = null;

    [MenuItem("Level Generator/Generate Level")]
    public static void GenerateGrid()
    {
        LoadPropsLibrary();
        LoadBiomeLibraries();

        levelGrid =
            GameObject.FindObjectOfType<LevelGridView>();
        if (initialChildCount == 0)
        {
            initialChildCount = levelGrid.transform.childCount;
        }

        ClearLevel();
        if (levelGrid.levelContainer == null)
        {
            levelGrid.levelContainer = new LevelContainerController();
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
                    InstantiateTile(grid[i, j, k], positionOfTile);

                    positionOfTile.y += levelGrid.levelSettings.tileSize.y;
                }

                positionOfTile.y = 0;
                positionOfTile.z += levelGrid.levelSettings.tileSize.z;
            }

            positionOfTile.z = 0;
            positionOfTile.x += levelGrid.levelSettings.tileSize.x;
        }
    }

    private static void LoadPropsLibrary()
    {
        Object[] prefabs = Resources.LoadAll("Prefabs/Props/Structural");

        foreach (Object obj in prefabs)
        {
            propsLibrary.Add((GameObject)obj);
        }
    }

    private static GameObject GenerateRandomProp(List<string> propsFilter)
    {
        List<GameObject> allowedProps = new List<GameObject>();

        foreach (string prop in propsFilter)
        {
            string pattern = string.Empty;
            for (int i = 0; i < prop.Length; i++)
            {
                if (i == prop.Length)
                {
                    pattern += "[1-9]";
                }
                else
                {
                    pattern += string.Format("[{0}]", prop[i]);
                }
            }

            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);

            foreach (GameObject obj in propsLibrary)
            {
                if (regex.IsMatch(obj.name) == false)
                {
                    allowedProps.Add(obj);
                }
            }
        }

        if (allowedProps.Count <= 0)
        {
            throw new System.Exception("Not a single prop was selected from the props library, please make sure any of the filters you used do not prevent ALL of the props from matching.");
        }
        else
        {
            GameObject newProp = GameObject.Instantiate(allowedProps[Random.Range(0, allowedProps.Count)]);

            return newProp;
        }
    }

    private static void SetupLevel()
    {
        for (int i = 0; i < levelGrid.levelContainer.GetGridArray().GetLength(0); i++)
        {
            for (int j = 0; j < levelGrid.levelContainer.GetGridArray().GetLength(1); j++)
            {
                for (int k = 0; k < levelGrid.levelContainer.GetGridArray().GetLength(2); k++)
                {
                    levelGrid.levelContainer.GetGridArray()[i, j, k] = "Water";
                }
            }
        }

        int x = 0;
        int y = 0;

        for (x = 0; x < levelGrid.levelContainer.GetGridArray().GetLength(0); x++)
        {
            levelGrid.levelContainer.GetGridArray()[x, 0, 0] = "Ocean Floor";

            for (y = 0; y < levelGrid.levelContainer.GetGridArray().GetLength(1); y++)
            {
                levelGrid.levelContainer.GetGridArray()[x, y, 0] = "Ocean Floor";
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
        switch (tileAssetName + "s")
        {
            case "Ocean Floors":
                if (oceanFloorContainer == null)
                {
                    oceanFloorContainer = new GameObject(tileAssetName + "s").transform;
                    oceanFloorContainer.transform.SetParent(levelGrid.transform);
                }
                break;
            case "Waters":
                if (waterContainer == null)
                {
                    waterContainer = new GameObject(tileAssetName + "s").transform;
                    waterContainer.transform.SetParent(levelGrid.transform);
                }
                break;
        }


        if (tileObj != null)
        {
            tileObj = GameObject.Instantiate(tileObj, GameObject.Find(tileAssetName + "s").transform);

            tileObj.transform.position = position;

            List<string> tilesToFilter = new List<string>()
                {
                    "Water(Clone)"
                };

            if (tilesToFilter.Contains(tileObj.name) == false)
            {
                if (Random.Range(0, 100) > 60)
                {
                    GameObject newProp = GenerateRandomProp(new 
                        List<string>()
                        {
                            "Bigrock"
                        });

                    newProp.transform.position = Vector3.zero;
                    newProp.transform.SetParent(tileObj.transform);
                    newProp.transform.position = new Vector3(
                        tileObj.transform.position.x,
                        tileObj.transform.position.y,
                        tileObj.transform.position.z
                        );
                }
            }
        }
    }

    private static void ClearLevel()
    {
        // We start from 1 because we want to avoid deleting the camera container.
        List<GameObject> children = new List<GameObject>();
        for (int i = initialChildCount; i < levelGrid.transform.childCount; i++)
        {
            children.Add(levelGrid.transform.GetChild(i).gameObject);
        }

        foreach (GameObject obj in children)
        {
            // DestroyImmediate is dangerous, test this code first
            //GameObject.DestroyImmediate(obj);
        }
    }

    [MenuItem("Level Generator/Generate New Scene")]
    [System.Obsolete]
    public static void GenerateNewScene()
    {
        EditorApplication.SaveCurrentSceneIfUserWantsTo();
        if (levelPrefab == null)
        {
            levelPrefab = (GameObject)Resources.Load("LevelView");
        }
        EditorApplication.NewEmptyScene();
        GameObject level = GameObject.Instantiate(levelPrefab);
        level.name = levelPrefab.name;
    }
}
