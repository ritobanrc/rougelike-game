using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectAll : MonoBehaviour {

    /// <summary>
    /// The object that holds all the info
    /// </summary>
    public GameObject ChestItems;

    /// <summary>
    /// Set image and text to be off on start
    /// </summary>
    private void Start()
    {
        this.GetComponent<Image>().enabled = false;
        this.transform.GetChild(0).GetComponent<Text>().enabled = false;
    }

    /// <summary>
    /// Tell ChestItems that it was clicked on
    /// </summary>
    public void ClickedOn ()
    {
        ChestItems.GetComponent<ChestItemController>().CollectAll();
    }

    /// <summary>
    /// shows or deactivates the image and text
    /// </summary>
    public void Open ()
    {
        if (this.GetComponent<Image>().enabled == false) this.GetComponent<Image>().enabled = true; else this.GetComponent<Image>().enabled = false;
        if (this.transform.GetChild(0).GetComponent<Text>().enabled == true) this.transform.GetChild(0).GetComponent<Text>().enabled = false; else this.transform.GetChild(0).GetComponent<Text>().enabled = true;
    }
}
