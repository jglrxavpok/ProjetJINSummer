using System;
using UnityEngine;

namespace JINSummer.GeneralBehaviours {
    public class Patrol : PhysicsBase {
        public float movementSpeed = 5f;
        
        private bool goLeft = true;
        
        // TODO: don't fall off platforms
        
        /// <summary>
        /// Called by PhysicsBase when wall is hit
        /// </summary>
        public void HitWall() {
            goLeft = !goLeft;
        }

        private void Update() {
            int direction = goLeft ? -1 : 1;
            velocity.x = movementSpeed * direction;
            base.Update();
        }
    }
}