using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemVisuals : MonoBehaviour
{
    private InvintoryMangager inventory = new InvintoryMangager();
    public Sprite[] sprites;

    private void Start()
    {
        inventory.AddItem(1,72);
        for (int i = 0; i < 40; i++)
        {
            this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled = false;
            this.transform.GetChild(i).GetComponent<Image>().enabled = false;
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
    }

    public void ShowItems()
    {
        for (int i = 0; i < 40; i++)
        {
            if (this.transform.GetChild(i).GetComponent<Image>().enabled == false) this.transform.GetChild(i).GetComponent<Image>().enabled = true; else this.transform.GetChild(i).GetComponent<Image>().enabled = false;
            if (this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled == false && inventory.StackAsInt(i) != 0) this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled = true; else this.transform.GetChild(i).GetChild(0).GetComponent<Text>().enabled = false;
        }
    }
}