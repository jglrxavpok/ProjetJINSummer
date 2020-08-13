using System;
using UnityEngine;

namespace JINSummer.Animations {
    public class Player : MonoBehaviour {
        public Animator animator;
        public PhysicsBase physics;
        public SpriteRenderer spriteRenderer; // for flipping the sprite
        private static readonly int VerticalSpeed = Animator.StringToHash("Vertical Speed");

        public void Update() {
            Vector2 velocity = physics.GetVelocityRef();
            
            animator.SetFloat(VerticalSpeed, velocity.y);

            bool flipX = velocity.x < float.Epsilon;

            spriteRenderer.flipX = flipX;
        }
    }
}
