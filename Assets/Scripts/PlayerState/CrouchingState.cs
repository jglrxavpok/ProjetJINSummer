using UnityEngine;

namespace JINSummer.PlayerStates {
    public class CrouchingState: PlayerState {
        private static CrouchingState instance = null;
        
        private CrouchingState() {
            
        }

        public static CrouchingState Instance() {
            if (instance == null) {
                instance = new CrouchingState();
            }
            return instance;
        }

        public override void Update(GameObject gameObject, PlayerControl playerControl) {}

        public override void TransitionIn(GameObject playerObj, PlayerControl playerController) {}

        public override void TransitionOut(GameObject playerObj, PlayerControl playerController) {}

        public override bool AllowRunning() {
            return false;
        }

        public override bool AllowJumping() {
            return false;
        }

        public override bool AllowCrouching() {
            return true;
        }
    }
}
