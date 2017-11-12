using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestItemController : MonoBehaviour
{
    private bool pressed = false;

    public GameObject inventoryItems;

    private int slotSelected = -1;

    private InvintoryMangager[] inventory;
    public int chestAmount;
    public Sprite[] sprites;

    private int chestOpened = -1;

    private void Start()
    {
        inventory = new InvintoryMangager[chestAmount];
        for (int i = 0; i < chestAmount; i++)
        {
            inventory[i] = new InvintoryMangager();
            for (int n = 0; n < Random.Range(0,40); n++)
            {
                inventory[i].AddItem(Random.Range(0, 2), Random.Range(0, 128));
            }
        }
        for (int i = 0; i < 40; i++)
        {
            this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled = false;
            this.transform.GetChild(i).GetComponent<Image>().enabled = false;
            this.transform.GetChild(i).GetComponent<ChestButtonController>().slot = i;
        }
    }

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
    public void ItemClickedOn(int slot)
    {
        inventoryItems.GetComponent<InventoryItemVisuals>().AddItem(inventory[chestOpened].ItemAsInt(slot), inventory[chestOpened].StackAsInt(slot));
        inventory[chestOpened].ResetSlot(slot);
    }
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
}