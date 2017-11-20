using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestGridController : MonoBehaviour
{
    /// <summary>
    /// When start make sure the grid is not showing
    /// </summary>
    private void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            this.transform.GetChild(i).GetComponent<Image>().enabled = false;
        }
    }

    /// <summary>
    /// Open or Close the grid
    /// </summary>
    public void openChestGrid ()
    {
        for (int i = 0; i < 40; i++)
        {
            if (this.transform.GetChild(i).GetComponent<Image>().enabled == false) this.transform.GetChild(i).GetComponent<Image>().enabled = true; else this.transform.GetChild(i).GetComponent<Image>().enabled = false;
        }
    }
}
