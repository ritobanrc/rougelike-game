using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestButtonController : MonoBehaviour
{
    public int slot = 0;
    public void ClickedOn()
    {
        this.GetComponentInParent<ChestItemController>().ItemClickedOn(this.slot);
    }
}
