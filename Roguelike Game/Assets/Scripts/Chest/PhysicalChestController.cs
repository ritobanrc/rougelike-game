using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhysicalChestController : MonoBehaviour
{
    /// <summary>
    /// The chest grid
    /// </summary>
    public GameObject chestGrid;

    /// <summary>
    /// The chest items
    /// </summary>
    public GameObject chestItems;

    /// <summary>
    /// The inventoryItems
    /// </summary>
    public GameObject inventoryItems;

    /// <summary>
    /// The inventory grid
    /// </summary>
    public GameObject inventoryGrid;

    /// <summary>
    /// The player
    /// </summary>
    public GameObject playerObject;

    /// <summary>
    /// The collect all button
    /// </summary>
    public GameObject CollectAllButton;

    /// <summary>
    /// Whitch chest this is
    /// </summary>
    public int chestNum = 0;

    /// <summary>
    /// Whether e was pressed or not
    /// </summary>
    private bool pressed = false;

	/// <summary>
    /// Checks if player is there and opens grids and items
    /// </summary>
	void LateUpdate ()
    {
		if ((playerObject.transform.position - this.transform.position).sqrMagnitude < 1.01 && playerObject.GetComponent<PlayerMovement>().currentlyMoving == false) if (Input.GetAxisRaw("Inventory") == 1 && pressed == false)
        {
            chestGrid.GetComponent<ChestGridController>().openChestGrid();
            chestItems.GetComponent<ChestItemController>().OpenChestItem(chestNum);
            CollectAllButton.GetComponent<CollectAll>().Open();
            if (chestGrid.transform.GetChild(0).GetComponent<Image>().enabled == true)
            {
                    inventoryGrid.GetComponent<InventoryVisualController>().Open();
                    inventoryItems.GetComponent<InventoryItemVisuals>().Open();
            }
            pressed = true;
            playerObject.GetComponent<PlayerMovement>().moveable = ReverseBool(chestGrid.transform.GetChild(0).GetComponent<Image>().enabled);
        }
        else if (Input.GetAxisRaw("Inventory") == 0) pressed = false;
    }

    /// <summary>
    /// Reveres bool
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private bool ReverseBool(bool input)
    {
        if (input == true) return false; else return true;
    }
}