using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestGroup : MonoBehaviour
{
    public int childAmount = 0;
    private void Start()
    {
        for (int i = 0; i < childAmount; i++)
        {
            this.transform.GetChild(i).GetComponent<PhysicalChestController>().chestNum = i;
        }
    }
}
