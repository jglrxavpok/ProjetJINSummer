using UnityEngine;

namespace JINSummer {
    public class PlayerShoot : Shoot {
        protected override bool ShouldShoot() {
            return Input.GetAxis("Shoot") > 0.1;
        }
    }
}
