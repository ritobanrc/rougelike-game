using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coord
{
    public int X { get; protected set; }
    public int Y { get; protected set; }
    public Vector2 AsV2
    {
        get
        {
            return new Vector2(this.X, this.Y);
        }
    }

    public Coord(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public static Coord operator +(Coord a, Coord b)
    {
        return new Coord(a.X + b.X, a.Y + b.Y);
    }

    public override string ToString()
    {
        return "Coord: (" + this.X + ", " + this.Y + ")";
    }
}
