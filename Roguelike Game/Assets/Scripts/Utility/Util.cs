using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Utility
{
    static class Util
    {
        public static float Remap(this float value, float from1, float to1, float from2, float to2)
        {
            return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
        }

        public static float RoundToNearestHalf(this float a)
        {
            return a = Mathf.Round(a * 2f) * 0.5f;
        }

        public static Vector3 RoundToNearestHalf(this Vector3 a)
        {
            return new Vector3(a.x.RoundToNearestHalf(), a.y.RoundToNearestHalf(), a.z.RoundToNearestHalf());
        }

        public static void SetLayerRecursively(this GameObject obj, int layer)
        {
            obj.layer = layer;
            foreach (Transform child in obj.transform)
            {
                child.gameObject.SetLayerRecursively(layer);
            }
        }

        public static void SetSortingLayerRecursively(this GameObject obj, string layer)
        {
            if (obj.GetComponent<Renderer>() != null)
                obj.GetComponent<Renderer>().sortingLayerName = layer;
            if (obj.GetComponent<Canvas>() != null)
                obj.GetComponent<Canvas>().sortingLayerName = layer;
            foreach (Transform child in obj.transform)
            {
                child.gameObject.SetSortingLayerRecursively(layer);
            }
        }

        public static float ManhattanDistance(Vector3 a, Vector3 b)
        {

            return Mathf.Abs(a.x - b.x) + Mathf.Abs(a.y - b.y) + Mathf.Abs(a.z - b.z);

        }
    }
}
