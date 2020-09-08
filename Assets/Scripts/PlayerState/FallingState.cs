using UnityEngine;

namespace JINSummer.PlayerStates {
    public class FallingState: PlayerState {
        private static FallingState instance = null;
        
        private FallingState() {
            
        }

        public static FallingState Instance() {
            if (instance == null) {
                instance = new FallingState();
            }
            return instance;
        }

        public override void Update(GameObject gameObject, PlayerControl playerControl) {
            // apply additional gravity to make jump snappier
            playerControl.GetVelocityRef().y += Time.deltaTime * playerControl.gravity * 0.5f;
        }

        public override void TransitionIn(GameObject playerObj, PlayerControl playerController) {}

        public override void TransitionOut(GameObject playerObj, PlayerControl playerController) {
            playerController.groundParticles.Play();
        }

        public override bool AllowAirControl() {
            return true;
        }

        public override bool AllowRunning() {
            return false;
        }
    }
}
