using System;
using UnityEngine;
using UnityEngine.UI;

namespace JINSummer.Saves {
    public class HighscoreRenderer : MonoBehaviour {
        private Text text;

        private void Start() {
            text = GetComponent<Text>();
            string contents = "";
            for (int i = 0; i < HighScores.Scores.Length; i++) {
                int score = HighScores.Scores[i];
                contents += "<color=cyan>"+(i+1)+"</color>" + ": " + score.ToString(ScoreTracker.format);
                if (i % 2 != 0) {
                    contents += "\n";
                } else {
                    contents += "  ";
                }
            }

            text.text = contents;
        }
    }
}
