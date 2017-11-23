using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TileType
{
    public string Name { get; protected set; }
    public int TileTypeId { get; protected set; }
    public Color32 LvlImgColor;

    public TileType(string name, int tileTypeId)
    {
        Name = name;
        TileTypeId = tileTypeId;
    }
}
