using UnityEngine;

namespace JINSummer.PlayerStates {
    public class RunningState: PlayerState {
        private static RunningState instance = null;
        
        private RunningState() {
            
        }

        public static RunningState Instance() {
            if (instance == null) {
                instance = new RunningState();
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
    }
}
