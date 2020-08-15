using System;
using UnityEngine;

namespace JINSummer {
    public class AimToTarget : Aim {
        public GameObject target;

        public void Update() {
            Vector2 directionVec = target.transform.position - transform.position;
            direction = directionVec.ClosestDirection();
        }
    }
}
