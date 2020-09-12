using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JINSummer {
    public class NextLevelTrigger : MonoBehaviour {
        public string nextLevelName;

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                SceneManager.LoadScene(nextLevelName);
            }
        }
    }
}
