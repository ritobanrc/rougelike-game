using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvintoryMangager {

    /// <summary>
    /// List of the items in 
    /// </summary>
    public InventoryItem[] inventory;

    /// <summary>
    /// Defines a size for the inventory
    /// </summary>
    public int InventorySize = 40;

    /// <summary>
    /// Defines the size of the stack
    /// </summary>
    public int StackSize = 64;

    /// <summary>
    /// Sets up array
    /// </summary>
    public InvintoryMangager()
    {
        inventory = new InventoryItem[InventorySize];
        for (int i = 0; i < InventorySize; i++)
        {
            inventory[i] = new InventoryItem(-1);
        }
    }

    /// <summary>
    /// returns the slot as int
    /// </summary>
    /// <returns></returns>
    public int ItemAsInt(int place)
    {
        if (place >= InventorySize) place = InventorySize - 1;
        return inventory[place].itemAsi();
    }

    public int StackAsInt(int place)
    {
        if (place >= InventorySize) place = InventorySize - 1;
        return inventory[place].stackAsi();
    }

    /// <summary>
    /// Adds an item to the inventory
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="itemNub"></param>
    /// <returns></returns>
    public bool AddItem(int itemType, int itemNum = 1)
    {
            for (int i = 0; i < InventorySize; i++)
            {
                if (inventory[i].itemAsi() != -1)
                {
                    if (inventory[i].itemAsi() == itemType)
                    {
                        if (inventory[i].stackAsi() + itemNum <= StackSize)
                        {
                            inventory[i].AddToStack(itemNum);
                        }
                    }
                }
            }
        bool compleated = false;
        while (!compleated)
        {
            int add = itemNum;
            while (add > 64)
            {
                for (int i = 0; i < InventorySize; i++)
                {
                    if (inventory[i].itemAsi() == -1)
                    {
                        inventory[i].setItem(itemType);
                        inventory[i].AddToStack(64);
                        break;
                    }
                }
                add -= 64;
            }
            for (int i = 0; i < InventorySize; i++)
            {
                if (inventory[i].itemAsi() == -1)
                {
                    inventory[i].setItem(itemType);
                    inventory[i].AddToStack(add);
                    return true;
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Removes an item from the inventory
    /// </summary>
    /// <param name="itemType"></param>
    /// <param name="itemNum"></param>
    /// <returns></returns>
    public bool RemoveItem(int itemType, int itemNum = 1)
    {
        for (int i = 0; i < InventorySize; i++)
        {
            if (inventory[i].itemAsi() != -1)
            {
                if (inventory[i].itemAsi() == itemType)
                {
                    if (inventory[i].stackAsi() < StackSize)
                    {
                        if (inventory[i].RemoveFromStack(itemNum)) inventory[i] = null;
                        return true;
                    }
                }
            }
            else break;
            }
        return false;
    }
}