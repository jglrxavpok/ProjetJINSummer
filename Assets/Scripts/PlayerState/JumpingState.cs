using UnityEngine;

namespace JINSummer.PlayerStates {
    public class JumpingState: PlayerState {
        private static JumpingState instance = null;
        
        private JumpingState() {
            
        }

        public static JumpingState Instance() {
            if (instance == null) {
                instance = new JumpingState();
            }
            return instance;
        }

        public override void TransitionIn(GameObject playerObj, PlayerControl playerController) {
            playerController.audioSource.PlayOneShot(playerController.jumpingSound, AudioListener.volume);
        }

        public override void TransitionOut(GameObject playerObj, PlayerControl playerController) {}

        public override bool AllowRunning() {
            return false;
        }
        
        public override bool AllowAirControl() {
            return true;
        }
        
        // TODO: AllowJumping for a double jump?
    }
}
