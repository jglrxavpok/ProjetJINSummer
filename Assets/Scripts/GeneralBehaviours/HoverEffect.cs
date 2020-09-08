using System;
using UnityEngine;

namespace JINSummer.GeneralBehaviours {
    public class HoverEffect : MonoBehaviour {

        public float hoverFrequency = 1.0f;
        public float hoverAmplitude = 1.0f;
        private Vector3 startPosition;
        
        private void Start() {
            startPosition = transform.position;
        }

        private void Update() {
            transform.position = startPosition + Vector3.up * (Mathf.Sin(Time.time * hoverFrequency) * hoverAmplitude);
        }
    }
}
