using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Responsible for importing worlds. Now, that only means generating the world from a pre-defined level image. 
/// </summary>
public static class WorldImporter 
{
    // Ignore this ugliness. It's just a basic property/field setup that can be ignored
    private static Dictionary<Color32, FurniturePrototype> furnColorToProto = new Dictionary<Color32, FurniturePrototype>();
    public static Dictionary<Color32, FurniturePrototype> FurnColorToProto
    {
        get
        {
            return furnColorToProto;
        }

        set
        {
            furnColorToProto = value;
        }
    }

    public static World ImportWorldFromLevelImage(Texture2D tileMap, Texture2D furnMap)
    {

    }

    /// <summary>
    /// This actually creates a new world and imports just the furniture. Sorry for the horrible naming. This is all mostly temporary anyway. See #4 and #6
    /// </summary>
    /// <param name="texture"></param>
    /// <returns></returns>
    public static World ImportFurnitureForLevel(Texture2D texture)
    {
        int width = texture.width;
        int height = texture.height;
        Debug.Log("Importing World of size " + width + " by " + height + " from " + texture.name);
        // Get the pixels. To avoid floating point drift, we get the colors as 32 bit integers instead of floats
        Color32[] pixels = texture.GetPixels32();

        World world = new World(width, height);


        for (int i = 0; i < width; i++)
        {
            for(int j = 0; j < height; j++)
            {
                Color32 c = pixels[j * width + i];
                Tile t = world.GetTileAt(i, j);
                if (FurnColorToProto.ContainsKey(c))
                {
                    // There is a furniture
                    //Debug.Log("Furniture " + FurnColorToProto[c].Name + " recognized");
                    t.Furniture = new Furniture(FurnColorToProto[c], t);
                }
            }
        }

        return world;
    }
}
