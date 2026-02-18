using System.Collections;
using UnityEngine;

namespace Player {
    public static class Player {
        public static float Speed = 100f;
        public static float Strength = 1.5f;
        public static bool IsAutoLaunchActive = false;
        public static Vector3 Scale = Vector3.one;
        public static float Mass = 10f;
        
        public static IEnumerator ResetStats(float time) {
            yield return new WaitForSeconds(time);
            Speed = 100f;
            IsAutoLaunchActive = false;
            Scale = Vector3.one;
            Mass = 10f;
        }
       
    }
}