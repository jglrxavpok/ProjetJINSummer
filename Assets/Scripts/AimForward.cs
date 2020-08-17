using System;
using UnityEngine;

namespace JINSummer {
    [RequireComponent(typeof(PhysicsBase))]
    public class AimForward : Aim {
        private PhysicsBase physics;

        private void Start() {
            physics = GetComponent<PhysicsBase>();
        }

        private void Update() {
            AimDirection aim = physics.GetVelocityRef().ClosestDirection();
            if (aim != AimDirection.LAST) {
                direction = aim;
            }
        }
    }
}