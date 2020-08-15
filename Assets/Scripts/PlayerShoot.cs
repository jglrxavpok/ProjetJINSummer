using UnityEngine;

namespace JINSummer {
    public class PlayerShoot : Shoot {
        protected override bool ShouldShoot() {
            return Input.GetButton("Shoot");
        }
    }
}
