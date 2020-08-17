using System;
using UnityEngine;

namespace JINSummer.GeneralBehaviours {
    public class Sensor : MonoBehaviour {
        public String messageToSendOnEnter;
        public String messageToSendOnExit;
        public String tag;

        private void OnTriggerEnter2D(Collider2D other) {
            if (!other.CompareTag(tag)) return;
            if (messageToSendOnEnter != null) {
                gameObject.SendMessageUpwards(messageToSendOnEnter, SendMessageOptions.DontRequireReceiver);
            }
        }
        
        private void OnTriggerExit2D(Collider2D other) {
            if (!other.CompareTag(tag)) return;
            if (messageToSendOnEnter != null) {
                gameObject.SendMessageUpwards(messageToSendOnExit, SendMessageOptions.DontRequireReceiver);
            }
        }

    }
}