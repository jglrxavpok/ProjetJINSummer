using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JINSummer {
    public class GameoverMenuScript : MonoBehaviour {

        private bool active = false;
        
        public void Trigger() {
            for (int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).gameObject.SetActive(true);
            }

            active = true;
        }

        private void Update() {
            if (!active) {
                return;
            }
            if (Input.GetButton("Submit")) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            if (Input.GetButton("Cancel")) {
                GameObject.FindWithTag("Score").GetComponent<ScoreTracker>().SaveAndReset();
                SceneManager.LoadScene("Main Menu");
            }
        }
    }
}
