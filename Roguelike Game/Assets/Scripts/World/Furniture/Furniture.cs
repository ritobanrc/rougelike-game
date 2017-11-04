using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// Something that exists on a tile and cannot easily be moved (i.e. A wall, a chest, a rock, a table). Created from Furniture Prototype
/// </summary>
public class Furniture
{
    public FurniturePrototype Prototype { get; protected set; }
    public readonly Tile tile;

    public Furniture(FurniturePrototype prototype, Tile tile)
    {
        Prototype = prototype;
        this.tile = tile;
    }

    public string Name { get { return Prototype.Name; } }
}

