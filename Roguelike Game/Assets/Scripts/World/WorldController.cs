using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// A Global Component holding information about the world
/// </summary>
public class WorldController : MonoBehaviour
{
    /// <summary>
    /// The whole world.
    /// </summary>
    public World World { get; protected set; }

    public Texture2D TileTypeMap;
    public Texture2D FurnitureMap;

    private void Awake()
    {
        World = WorldImporter.ImportWorldFromLevelImage(TileTypeMap, FurnitureMap);
        GetComponent<WorldGameObjectCreator>().CreateWorldGameObjects(World);
    }
}
