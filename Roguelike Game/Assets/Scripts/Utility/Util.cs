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
    }
}
