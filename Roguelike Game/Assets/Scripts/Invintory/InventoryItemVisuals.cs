using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemVisuals : MonoBehaviour
{ 
    private bool pressed = false;

    private int slotSelected = -1;

    private InvintoryMangager inventory = new InvintoryMangager();
    public Sprite[] sprites;

    private void Start()
    {
        inventory.AddItem(1, 120);
        inventory.AddItem(1, 52);
        inventory.AddItem(0, 32);
        for (int i = 0; i < 40; i++)
        {
            this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled = false;
            this.transform.GetChild(i).GetComponent<Image>().enabled = false;
            this.transform.GetChild(i).GetComponent<InventoryItemButtonHandler>().slot = i;
        }
    }

    private void Update() 
    {
        for (int i = 0; i < 40; i++)
        {
            if (this.transform.GetChild(i).GetComponent<Image>().enabled == true)
            {
                this.transform.GetChild(i).GetComponent<Image>().sprite = sprites[inventory.ItemAsInt(i)+1];
                this.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = (inventory.StackAsInt(i)).ToString();
                if (inventory.StackAsInt(i) == 0) this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled = false;
                if (inventory.StackAsInt(i) != 0) this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled = true;
            }
        }
        if (Input.GetAxisRaw("Inventory") == 1 && pressed == false)
        {
            for (int i = 0; i < 40; i++)
            {
                if (this.transform.GetChild(i).GetComponent<Image>().enabled == false) this.transform.GetChild(i).GetComponent<Image>().enabled = true; else this.transform.GetChild(i).GetComponent<Image>().enabled = false;
                if (this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled == false && inventory.StackAsInt(i) != 0) this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled = true; else this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled = false;
            }
            pressed = true;
        }
        else if (Input.GetAxisRaw("Inventory") == 0) pressed = false;
    }
        public void ItemClickedOn(int slot)
        {
            Debug.Log("Item clicked on");
            if (slotSelected == -1)
            {
                slotSelected = slot;
                this.transform.GetChild(slotSelected).GetComponent<Image>().color = new Color(0.68627451f, 0.68627451f, 0.68627451f);
                Debug.Log("Slot Selected");
            }
            else
            {
                this.transform.GetChild(slotSelected).GetComponent<Image>().color = new Color(1f, 1f, 1f);
                inventory.SwitchSlots(slot, slotSelected);
                slotSelected = -1;
                Debug.Log("Slots switched");
            }
        }
}