using UnityEngine;

namespace JINSummer.PlayerStates {
    public class IdleState: PlayerState {
        private static IdleState instance = null;
        
        private IdleState() {
            
        }

        public static IdleState Instance() {
            if (instance == null) {
                instance = new IdleState();
            }
            return instance;
        }

        public override void TransitionIn(GameObject playerObj, PlayerControl playerController) {}

        public override void TransitionOut(GameObject playerObj, PlayerControl playerController) {}

        public override bool AllowRunning() {
            return true;
        }

        public override bool AllowJumping() {
            return true;
        }
        
        public override bool AllowCrouching() {
            return true;
        }
    }
}
