using UnityEngine;

namespace JINSummer.PlayerStates {
    public class ShowGameoverMenuOnDeath : MonoBehaviour {
        public void OnDeath() {
            GameObject gameover = GameObject.FindWithTag("Gameover");
            gameover.GetComponent<GameoverMenuScript>().Trigger();
            
            GameObject.FindWithTag("Score").GetComponent<ScoreTracker>().IncreaseScore(-100);
        }
    }
}
