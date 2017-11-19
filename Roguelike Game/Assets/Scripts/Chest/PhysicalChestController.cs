using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhysicalChestController : MonoBehaviour
{
    public GameObject chestGrid;

    public GameObject chestItems;

    public GameObject inventoryItems;

    public GameObject inventoryGrid;

    public GameObject playerObject;

    public GameObject CollectAllButton;

    public int chestNum = 0;

    private bool pressed = false;

	// Update is called once per frame
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
    private bool ReverseBool(bool input)
    {
        if (input == true) return false; else return true;
    }
}