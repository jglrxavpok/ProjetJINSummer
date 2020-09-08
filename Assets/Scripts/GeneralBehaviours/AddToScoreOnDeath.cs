using UnityEngine;

namespace JINSummer.GeneralBehaviours {
    public class AddToScoreOnDeath : MonoBehaviour {
        public int scoreAmount = 10;

        public void OnDeath() {
            GameObject.FindWithTag("Score").GetComponent<ScoreTracker>().IncreaseScore(scoreAmount);
        }
    }
}
