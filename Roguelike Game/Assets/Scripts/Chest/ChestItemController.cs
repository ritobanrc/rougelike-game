using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestItemController : MonoBehaviour
{
    /// <summary>
    /// Bool to determine if E was pressed all ready
    /// </summary>
    private bool pressed = false;

    /// <summary>
    /// Game object that holds all the info
    /// </summary>
    public GameObject inventoryItems;

    /// <summary>
    /// Whitch (if any) slot is selected
    /// </summary>
    private int slotSelected = -1;

    /// <summary>
    /// The script that holds amounts and names
    /// </summary>
    private Items items = new Items();

    /// <summary>
    /// An array of Mangagers
    /// </summary>
    private InvintoryMangager[] inventory;

    /// <summary>
    /// How many chests exist
    /// </summary>
    public int chestAmount;

    /// <summary>
    /// ALL the sprites (defined elsewere
    /// </summary>
    public Sprite[] sprites;

    /// <summary>
    /// Whitch chest is opened
    /// </summary>
    private int chestOpened = -1;

    /// <summary>
    /// defines inventory
    /// defines each chest and fills in randomly
    /// disables images
    /// </summary>
    private void Start()
    {
        inventory = new InvintoryMangager[chestAmount];
        for (int i = 0; i < chestAmount; i++)
        {
            inventory[i] = new InvintoryMangager();
            for (int n = 0; n < Random.Range(0,40); n++)
            {
                int type = Random.Range(0, 5);
                inventory[i].AddItem(type, Random.Range(0, items.stack[type]));
            }
        }
        for (int i = 0; i < 40; i++)
        {
            this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled = false;
            this.transform.GetChild(i).GetComponent<Image>().enabled = false;
            this.transform.GetChild(i).GetComponent<ChestButtonController>().slot = i;
        }
    }

    /// <summary>
    /// Updates text and sprites of the childern
    /// </summary>
    private void Update()
    {
        if (this.transform.GetChild(0).GetComponent<Image>().enabled == true && chestOpened != -1)
        {
            for (int i = 0; i < 40; i++)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = sprites[inventory[chestOpened].ItemAsInt(i) + 1];
                this.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = (inventory[chestOpened].StackAsInt(i)).ToString();
                if (inventory[chestOpened].StackAsInt(i) == 0) this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled = false;
                if (inventory[chestOpened].StackAsInt(i) != 0) this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled = true;
            }
        }
    }

    /// <summary>
    /// Determins what to do if a child was clicked on
    /// (Selects slot or switchs slot)
    /// </summary>
    /// <param name="slot"></param>
    public void ItemClickedOn(int slot)
    {
        if (inventoryItems.GetComponent<InventoryItemVisuals>().slotSelected == -1 || inventory[chestOpened].ItemAsInt(slot) != -1)
        {
            inventoryItems.GetComponent<InventoryItemVisuals>().AddItem(inventory[chestOpened].ItemAsInt(slot), inventory[chestOpened].StackAsInt(slot));
            inventory[chestOpened].ResetSlot(slot);
        }
        else
        {
            inventory[chestOpened].SetSlot(inventoryItems.GetComponent<InventoryItemVisuals>().inventory.ItemAsInt(inventoryItems.GetComponent<InventoryItemVisuals>().slotSelected), slot, inventoryItems.GetComponent<InventoryItemVisuals>().inventory.StackAsInt(inventoryItems.GetComponent<InventoryItemVisuals>().slotSelected));
            inventoryItems.GetComponent<InventoryItemVisuals>().inventory.ResetSlot(inventoryItems.GetComponent<InventoryItemVisuals>().slotSelected);
            inventoryItems.transform.GetChild(inventoryItems.GetComponent<InventoryItemVisuals>().slotSelected).GetComponent<Image>().color = new Color(1f, 1f, 1f);
            inventoryItems.GetComponent<InventoryItemVisuals>().slotSelected = -1;
        }
    }

    /// <summary>
    /// Activates or deactivates images and text
    /// </summary>
    /// <param name="chest"></param>
    public void OpenChestItem(int chest)
    {
        if (chestOpened == -1) chestOpened = chest; else chestOpened = -1;
        for (int i = 0; i < 40; i++)
        {
            if (this.transform.GetChild(i).GetComponent<Image>().enabled == false) this.transform.GetChild(i).GetComponent<Image>().enabled = true; else this.transform.GetChild(i).GetComponent<Image>().enabled = false;
            if (this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled == false && chestOpened != -1) if (inventory[chestOpened].StackAsInt(i) != 0) this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled = true; else this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled = false;
            if (chestOpened == -1) this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled = false;
        }
    }

    /// <summary>
    /// If the collect all button was pressed,
    /// Put all your stuff in the inventory
    /// </summary>
    public void CollectAll ()
    {
        for (int i = 0; i < 40; i++)
        {
            if (inventory[chestOpened].ItemAsInt(i) != -1)
            {
                inventoryItems.GetComponent<InventoryItemVisuals>().AddItem(inventory[chestOpened].ItemAsInt(i), inventory[chestOpened].StackAsInt(i));
                inventory[chestOpened].ResetSlot(i);
            }
        }
    }
}