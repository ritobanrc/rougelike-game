using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    /// <summary>
    /// This integer is the item type
    /// </summary>
    public int item { get; protected set; }

    /// <summary>
    /// Amount of items stacked
    /// </summary>
    public int stack { get; protected set; }

    // Returns the item in the slot as a float
    public int itemAsi()
    {
        return this.item;
    }

    // Returns the amount of items stacked
    public int stackAsi()
    {
        return this.item;
    }

    public void AddToStack(int amount = 1)
    {
        this.stack += amount;
    }

    public void RemoveFromStack(int amount = 1)
    {
        this.stack -= amount;
    }

    public InventoryItem (int item)
    {
        this.item = item;
        this.stack = 1;
    }
}