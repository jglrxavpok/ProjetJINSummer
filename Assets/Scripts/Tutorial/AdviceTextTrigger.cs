using System;
using UnityEngine;

namespace JINSummer.Tutorial {
    [RequireComponent(typeof(Collider2D))]
    public class AdviceTextTrigger : MonoBehaviour {
        public AdviceText adviceText;
        
        [TextArea(3,10)]
        public String toDisplay;
        
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("CameraWaveTrigger")) {
                adviceText.SetAdviceText(toDisplay);
                Destroy(this);
            }
        }
    }
}