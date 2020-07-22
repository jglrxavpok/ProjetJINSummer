using UnityEngine;

namespace JINSummer.Math {
    public static class AngleExtensions {
        public static float ToRadians(this float self) {
            return self / 180f * Mathf.PI;
        }

        public static float ToDegrees(this float self) {
            return self * 180f / Mathf.PI;
        }
    }
}
