using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectAll : MonoBehaviour {
    public GameObject ChestItems;

    private void Start()
    {
        this.GetComponent<Image>().enabled = false;
        this.transform.GetChild(0).GetComponent<Text>().enabled = false;
    }

    public void ClickedOn ()
    {
        ChestItems.GetComponent<ChestItemController>().CollectAll();
    }

    public void Open ()
    {
        if (this.GetComponent<Image>().enabled == false) this.GetComponent<Image>().enabled = true; else this.GetComponent<Image>().enabled = false;
        if (this.transform.GetChild(0).GetComponent<Text>().enabled == true) this.transform.GetChild(0).GetComponent<Text>().enabled = false; else this.transform.GetChild(0).GetComponent<Text>().enabled = true;
    }
}
