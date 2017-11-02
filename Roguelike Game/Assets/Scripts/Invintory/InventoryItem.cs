using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    /// <summary>
    /// This integer is the slot number in the player's inventory
    /// </summary>
    public int Slot { get; protected set; }
    public InventoryItem (int slot)
    {
        this.Slot = slot;
    }
}
