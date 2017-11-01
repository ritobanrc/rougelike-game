using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A utility class that represents a coordinate as 2 integers. 
/// </summary>
public class Coord
{
    /// <summary>
    /// The X Value
    /// </summary>
    public int X { get; protected set; }
    /// <summary>
    /// The Y Value
    /// </summary>
    public int Y { get; protected set; }
    /// <summary>
    /// This Coordinate as a UnityEngine.Vector2 (converts the integers to floats)
    /// </summary>
    public Vector2 AsV2
    {
        get
        {
            return new Vector2(this.X, this.Y);
        }
    }

    /// <summary>
    /// Creates a new coordinate given X and Y values.
    /// </summary>
    /// <param name="x">The X Value</param>
    /// <param name="y">The Y Value</param>
    public Coord(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    /// <summary>
    /// Adds to Coordinates together by adding their respective X and Y components
    /// </summary>
    /// <param name="a">The first coordinate</param>
    /// <param name="b">The second coordinate</param>
    /// <returns>The sum</returns>
    public static Coord operator +(Coord a, Coord b)
    {
        return new Coord(a.X + b.X, a.Y + b.Y);
    }

    /// <summary>
    /// Converts this to a string in the form "Coord: (X, Y)"
    /// </summary>
    /// <returns>A string</returns>
    public override string ToString()
    {
        return "Coord: (" + this.X + ", " + this.Y + ")";
    }
}
