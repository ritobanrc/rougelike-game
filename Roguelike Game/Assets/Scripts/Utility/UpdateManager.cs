/* UpdateManager.cs  
(c) 2017 Ritoban Roy-Chowdhury. All rights reserved 
 */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows use of the Timer Class
/// </summary>
public class UpdateManager : MonoBehaviour
{
    private static UpdateManager _instance;
    public static UpdateManager Instance
    {
        get
        {
            if (_instance == null)
                _instance = GameObject.FindObjectOfType<UpdateManager>();
            return _instance;
        }
    }
    public event Action<float> OnUpdate;


    private void Update()
    {
        if (OnUpdate != null)
            OnUpdate.Invoke(Time.deltaTime);
    }
}
