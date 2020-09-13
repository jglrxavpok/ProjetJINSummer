using System;
using JINSummer.Saves;
using UnityEngine;
using UnityEngine.UI;

namespace JINSummer {
    public class ScoreTracker : MonoBehaviour {
        public static string format = "00000";
        public float maxTime = 0.5f;
        public float sizeMultiplier = 0.25f;
        
        // Static to keep track along game
        private static int currentValue = 0;
        private Text text;
        private int startSize;
        private float animationTime = 0.0f;
        
        public static string Prefix = "Score: ";

        private void Start() {
            text = GetComponent<Text>();
            startSize = text.fontSize;
            UpdateText();
        }
        
        private void UpdateText() {
            text.text = Prefix + currentValue.ToString(format);
        }

        private void Update() {
            float textSizeMultiplier = 1.0f;
            if (animationTime > 0) {
                animationTime -= Time.deltaTime;
                textSizeMultiplier += animationTime/maxTime * sizeMultiplier;
            } else {
                animationTime = 0.0f;
            }

            text.transform.localScale = new Vector3(textSizeMultiplier, 1.0f, 1.0f);
        }

        public void IncreaseScore(int amount) {
            currentValue += amount;
            if (currentValue < 0) {
                currentValue = 0;
            }
            UpdateText();
            animationTime = maxTime;
        }

        public static void SaveAndReset() {
            HighScores.NewScore(currentValue);
            currentValue = 0;
        }

        public static int GetScore() {
            return currentValue;
        }
    }
}
