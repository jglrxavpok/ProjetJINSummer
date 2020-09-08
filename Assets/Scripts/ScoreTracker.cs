﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace JINSummer {
    public class ScoreTracker : MonoBehaviour {
        public string format = "00000000";
        public float maxTime = 0.5f;
        public float sizeMultiplier = 0.25f;
        
        private int currentValue = 456;
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
            UpdateText();
            animationTime = maxTime;
        }
    }
}
