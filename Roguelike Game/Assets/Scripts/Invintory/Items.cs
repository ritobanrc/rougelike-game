using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items {

    /// <summary>
    /// Creates Enum with all names
    /// </summary>
    public enum items { Steel, Gold, blueSword, redSword, purpleSword };

    /// <summary>
    /// Creates an array of stack sizes
    /// </summary>
    public int[] stack;

    /// <summary>
    /// Creats and Defines stack
    /// </summary>
	public Items () {
        stack = new int[6];
        stack[0] = 128;
        stack[1] = 64;
        stack[2] = 1;
        stack[3] = 1;
        stack[4] = 1;
        return;
	}
}