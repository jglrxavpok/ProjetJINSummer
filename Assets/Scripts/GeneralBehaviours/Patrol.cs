using System;
using UnityEngine;

namespace JINSummer.GeneralBehaviours {
    public class Patrol : PhysicsBase {
        public float movementSpeed = 5f;
        
        private bool goLeft = true;

        /// <summary>
        /// Called by PhysicsBase when wall is hit
        /// </summary>
        public void HitWall() {
            goLeft = !goLeft;
            print("hit wall");
        }

        private void Update() {
            int direction = goLeft ? -1 : 1;
            velocity.x = movementSpeed * direction;
            base.Update();
        }

        public void NoPlatformOnLeft() {
            goLeft = false; // no platform towards left
        }

        public void NoPlatformOnRight() {
            goLeft = true; // no platform towards right
        }
    }
}