using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items {

    public enum items { Steel, Gold, blueSword, redSword, purpleSword };
    public int[] stack;

	// Use this for initialization
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