using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestGroup : MonoBehaviour
{
    /// <summary>
    /// How many chests
    /// </summary>
    public int childAmount = 0;

    /// <summary>
    /// Tell every chest which chest it is
    /// </summary>
    private void Start()
    {
        for (int i = 0; i < childAmount; i++)
        {
            this.transform.GetChild(i).GetComponent<PhysicalChestController>().chestNum = i;
        }
    }
}
