using System;
using UnityEngine;

namespace JINSummer.Animations {
    public class Bullet : MonoBehaviour {
        public Animator animator;
        public PhysicsBase physics;
        public SpriteRenderer spriteRenderer; // for flipping the sprite
        private static readonly int Up = Animator.StringToHash("Up");
        private static readonly int Down = Animator.StringToHash("Down");
        private static readonly int Horizontal = Animator.StringToHash("Horizontal");
        private static readonly int DiagUp = Animator.StringToHash("DiagUp");
        private static readonly int DiagDown = Animator.StringToHash("DiagDown");

        public void Start() {
            AimDirection direction = physics.GetVelocityRef().ClosestDirection();

            // going left?
            bool flipX = direction == AimDirection.LEFT || direction == AimDirection.UP_LEFT ||
                         direction == AimDirection.DOWN_LEFT;

            switch (direction) {
                case AimDirection.UP:
                    animator.SetBool(Up, true);
                    break;
                
                case AimDirection.DOWN:
                    animator.SetBool(Down, true);
                    break;
                
                case AimDirection.UP_LEFT:
                case AimDirection.UP_RIGHT:
                    animator.SetBool(DiagUp, true);
                    break;
                
                case AimDirection.DOWN_LEFT:
                case AimDirection.DOWN_RIGHT:
                    animator.SetBool(DiagDown, true);
                    break;
                
                default:
                    animator.SetBool(Horizontal, true);
                    break;
            }

            spriteRenderer.flipX = flipX;
        }
    }
}
