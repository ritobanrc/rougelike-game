using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestButtonController : MonoBehaviour
{
    /// <summary>
    /// Whitch slot this is
    /// </summary>
    public int slot = 0;

    /// <summary>
    /// When clicked on tell the inventory this slot was clicked on
    /// </summary>
    public void ClickedOn()
    {
        this.GetComponentInParent<ChestItemController>().ItemClickedOn(this.slot);
    }
}
