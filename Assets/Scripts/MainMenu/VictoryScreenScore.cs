using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace JINSummer.MainMenu {
    public class VictoryScreenScore : MonoBehaviour {

        private Text text;
        
        private void Start() {
            text = GetComponent<Text>();
            text.text = ScoreTracker.GetScore().ToString(ScoreTracker.format);
            ScoreTracker.SaveAndReset();
        }

        private void Update() {
            if (Input.GetButton("Submit")) {
                SceneManager.LoadScene("Main Menu");
            }
        }
        
    }
}
