using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

/// <summary>
/// Describes a type of Furniture. Can be used to create a Furniture object
/// </summary>
public class FurniturePrototype
{
    // Name
    // Graphics - Maybe Graphic should be a separate, generic class that can be used to create the gameobjects.
    public string Name { get; protected set; }
    public string ImagePath { get; protected set; } // TODO: Complicate this.
    public Color32 LvlImgColor;

    public FurniturePrototype(string name, string imagePath)
    {
        Name = name;
        ImagePath = imagePath;
    }
}

