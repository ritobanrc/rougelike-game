using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A Data class which stores information about a specific tile and methods pertaining to it.
/// </summary>
public class Tile 
{
    /// <summary>
    /// The Tile Position
    /// </summary>
    public Coord Position { get; protected set; }
    /// <summary>
    /// Returns the tile X position
    /// </summary>
    public int X { get { return Position.X; } }
    /// <summary>
    /// Returns the tile Y position
    /// </summary>
    public int Y { get { return Position.Y; } }
    /// <summary>
    /// Furniture on Tile. 
    /// </summary>
    public Furniture Furniture; // Other classes can do whatever they want to the funiture we're carrying. 
    /// <summary>
    /// Creates a new tile
    /// </summary>
    /// <param name="x">The X coordinate of the new tile</param>
    /// <param name="y">The Y coordinate of the new tile</param>
    public Tile(int x, int y)
    {
        this.Position = new Coord(x, y);
    }
}
