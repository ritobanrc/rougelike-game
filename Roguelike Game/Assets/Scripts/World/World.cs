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

    /// <summary>
    /// Creates a new world and initialzes all the tiles in it
    /// </summary>
    /// <param name="width">X size of the world. 0 for infinite.</param>
    /// <param name="height">Y size of the world. 0 for infinite</param>
    public World(int width, int height)
    {
        if (width == 0 || height == 0)
            throw new NotImplementedException("Either width or height was 0. Infinite worlds not supported (yet)");

        this.Width = width;
        this.Height = height;
        this.Tiles = new Tile[width, height];
        for(int i = 0; i < this.Width; i++)
        {
            for (int j = 0; j < this.Height; j++)
            {
                this.Tiles[i, j] = new Tile(i, j);
            }
        }
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

    /// <summary>
    /// Calls the Coord version of this.
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public Tile GetTileAt(int x, int y)
    {
        return GetTileAt(new Coord(x, y));
    }
}
