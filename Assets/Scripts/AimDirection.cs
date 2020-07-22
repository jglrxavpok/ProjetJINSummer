using JINSummer.Math;
using UnityEngine;

namespace JINSummer {
    public enum AimDirection: int {
        RIGHT,
        UP_RIGHT,
        UP,
        UP_LEFT,
        LEFT,
        DOWN_LEFT,
        DOWN,
        DOWN_RIGHT,
        
        LAST
    }

    public static class AimDirectionExtensions {
        private static float anglePerSection = 2.0f * Mathf.PI / (int)AimDirection.LAST;
        
        /**
         * Closest direction to the given aim vector.
         * Will return LAST on BasicallyZero() vectors
         */
        public static AimDirection ClosestDirection(this Vector2 aim) {
            if (aim.BasicallyZero()) {
                return AimDirection.LAST;
            }
            float angle = aim.Angle() + anglePerSection/2.0f;
            int index = (int) Mathf.Floor(angle / anglePerSection);
            while (index < 0) {
                index += (int)AimDirection.LAST;
            }
            index %= (int)AimDirection.LAST;

            return (AimDirection) index;
        }

        /**
         * Get the angle corresponding to this aim direction
         * Returns NaN for AimDirection.LAST
         */
        public static float Angle(this AimDirection direction) {
            if (direction == AimDirection.LAST) {
                return float.NaN;                
            }

            return (int) direction * anglePerSection;
        }
    }
}
