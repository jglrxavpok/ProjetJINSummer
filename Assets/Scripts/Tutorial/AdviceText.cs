using System;
using UnityEngine;
using UnityEngine.UI;

namespace JINSummer.Tutorial {
    [RequireComponent(typeof(Text))]
    public class AdviceText : MonoBehaviour {

        private Text text;
        
        private void Start() {
            text = GetComponent<Text>();
        }

        public void SetAdviceText(String text) {
            this.text.text = text;
        }
    }
}