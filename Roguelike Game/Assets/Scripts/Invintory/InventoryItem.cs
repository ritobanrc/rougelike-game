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

    /// <summary>
    /// Returns the amount of items stacked
    /// </summary>
    /// <returns></returns>
    public int stackAsi()
    {
        return this.stack;
    }

    /// <summary>
    /// Adds an item to the stack
    /// </summary>
    /// <param name="amount"></param>
    public void AddToStack(int amount = 1)
    {
        this.stack += amount;
    }

    /// <summary>
    /// Removes an item from the stack. If it is empty it returns true;
    /// </summary>
    /// <param name="amount"></param>
    /// <returns></returns>
    public bool RemoveFromStack(int amount = 1)
    {
        this.stack -= amount;
        if (this.stack == 0) return true; else return false;
    }

    /// <summary>
    /// Sets up the item when created;
    /// </summary>
    /// <param name="item"></param>
    public InventoryItem (int item, int stack = 0)
    {
        this.item = item;
        this.stack = stack;
    }

    public void setItem(int item)
    {
        this.item = item;
    }
}