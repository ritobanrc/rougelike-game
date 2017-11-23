using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utility
{
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = GameObject.FindObjectOfType<T>();
                }
                return _instance;
            }
        }
        private static T _instance;
    }
}