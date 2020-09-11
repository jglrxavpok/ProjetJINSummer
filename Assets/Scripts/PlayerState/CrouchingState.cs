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

        public override void TransitionIn(GameObject playerObj, PlayerControl playerController) {
            float angle = 90f;
            if (playerController.GetVelocityRef().x > 0) {
                angle = -90f;
            }

            playerController.crouchCollider.enabled = true;
            playerController.usualCollider.enabled = false;
            playerController.renderer.transform.rotation = Quaternion.Euler(0, 0, angle);
            playerController.renderer.transform.localPosition = new Vector3(0, -0.03f, 0);
        }

        public override void TransitionOut(GameObject playerObj, PlayerControl playerController) {
            playerController.crouchCollider.enabled = false;
            playerController.usualCollider.enabled = true;
            
            playerController.renderer.transform.rotation = Quaternion.Euler(0, 0, 0);
            playerController.renderer.transform.localPosition = new Vector3(0, 0.03f, 0);
        }

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
