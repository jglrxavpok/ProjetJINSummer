using UnityEngine;

namespace JINSummer.PlayerStates {
    public abstract class PlayerState {
        public abstract void TransitionIn(GameObject playerObj, PlayerControl playerController);
        public abstract void TransitionOut(GameObject playerObj, PlayerControl playerController);

        public virtual bool AllowRunning() {
            return false;
        }
        
        public virtual bool AllowJumping() {
            return false;
        }

        public virtual void Update(GameObject gameObject, PlayerControl playerControl) {}

        public virtual bool AllowCrouching() {
            return false;
        }

        public virtual bool AllowAirControl() {
            return false;
        }
    }
}
