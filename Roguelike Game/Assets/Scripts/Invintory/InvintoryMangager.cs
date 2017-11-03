using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvintoryMangager : MonoBehaviour {

    /// <summary>
    /// List of the items in 
    /// </summary>
    private List<InventoryItem> inventory = new List<InventoryItem>();

    /// <summary>
    /// Defines a size for the inventory
    /// </summary>
    public int InventorySize = 40;

    /// <summary>
    /// Defines the size of the stack
    /// </summary>
    public int StackSize = 64;

    public bool AddItem(int itemType, int itemNub = 1)
    {   
        for (int i = 0; i < InventorySize; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i].itemAsi() == itemType)
                {
                    if (inventory[i].stackAsi() < StackSize)
                    {
                        inventory[i].AddToStack(itemNub);
                        return true;      
                    }
                }
            } else break;
        }
        if (inventory.Count < InventorySize) return false;
        inventory.Add(new InventoryItem(itemType));
        return true;
    }
    public bool RemoveItem(int itemType, int itemNum = 1)
    {
        for (int i = 0; i < InventorySize; i++)
        {
            if (inventory[i] != null)
            {
                if (inventory[i].itemAsi() == itemType)
                {
                    if (inventory[i].stackAsi() < StackSize)
                    {
                        inventory[i].RemoveFromStack(itemNum);
                        return true;
                    }
                }
            }
            else break;
            }
        return false;
    }
}