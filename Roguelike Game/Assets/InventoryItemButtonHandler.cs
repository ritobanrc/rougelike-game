using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemButtonHandler : MonoBehaviour
{
    public int slot = 0;
     public void ClickedOn ()
    {
        Debug.Log("Item Clicked On");
        this.GetComponentInParent<InventoryItemVisuals>().ItemClickedOn(this.slot);
    }
}
