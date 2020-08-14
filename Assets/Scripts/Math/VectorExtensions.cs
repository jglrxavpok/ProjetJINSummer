using UnityEngine;

namespace JINSummer.Math {
    public static class VectorExtensions {
        /**
         * Checks if ||self||² &lt; epsilon
         */
        public static bool BasicallyZero(this Vector2 self, float epsilon = 10e-16f) {
            return Mathf.Abs(self.sqrMagnitude) < epsilon;
        }

        /**
         * Returns the angle of this vector, relative to (1,0), in trigonometric rotation (counter-clockwise).
         * If self is BasicallyZero(epsilon), return NaN
         */
        public static float Angle(this Vector2 self, float epsilon = 10e-16f) {
            if (self.BasicallyZero(epsilon)) {
                return float.NaN;
            }
            return Mathf.Atan2(self.y, self.x);
        }

        /**
         * Returns the angle between two vectors.
         * If self or other is BasicallyZero(epsilon), return NaN
         */
        public static float AngleTo(this Vector2 self, Vector2 other, float epsilon = 10e-16f) {
            if (self.BasicallyZero() || other.BasicallyZero()) {
                return float.NaN;
            }

            return Vector2.Dot(self, other) / (self.magnitude * other.magnitude);
        }
    }
}
