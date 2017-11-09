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

    public Texture2D LevelImage;

    private void Awake()
    {
        World = WorldImporter.ImportWorldFromLevelImage(LevelImage);
        GetComponent<WorldGameObjectCreator>().CreateWorldGameObjects(World);
    }
}
