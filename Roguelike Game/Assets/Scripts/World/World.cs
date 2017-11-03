using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A class that stores information about the world and methods pertaining to it. 
/// </summary>
public class World
{
    /// <summary>
    /// The Width of the World 
    /// </summary>
    public int Width { get; protected set; }
    /// <summary>
    /// The Height of the World
    /// </summary>
    public int Height { get; protected set; }
    /// <summary>
    /// A 2D Array of Tiles
    /// </summary>
    public Tile[,] Tiles { get; protected set; }

    public World(int width, int height)
    {
        this.Width = width;
        this.Height = height;
        this.Tiles = new Tile[width, height];
    }
    /// <summary>
    /// Gets a tile from the Tiles Array
    /// </summary>
    /// <param name="a">The Location of the Tile</param>
    /// <returns>The Tile located at <paramref name="a"/></returns>
    public Tile GetTileAt(Coord a)
    {
        if(a.X < 0 || a.Y < 0 || a.X >= Width || a.Y >= Height)
        {
            throw new ArgumentOutOfRangeException("a", "World::GetTileAt - " + a.ToString() + " is out of range");
        }
        return Tiles[a.X, a.Y];
    }
}
