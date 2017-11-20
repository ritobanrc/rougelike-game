using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemButtonHandler : MonoBehaviour
{
    /// <summary>
    /// Whitch slot is this
    /// </summary>
    public int slot = 0;

    /// <summary>
    /// When clicked on tell the parent that this slot was clicked on
    /// </summary>
    public void ClickedOn ()
    {
        this.GetComponentInParent<InventoryItemVisuals>().ItemClickedOn(this.slot);
    }
}
