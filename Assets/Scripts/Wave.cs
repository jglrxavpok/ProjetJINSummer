using System;
using System.Linq;
using UnityEngine;

namespace JINSummer {
    public class Wave : MonoBehaviour {
        private bool ongoing = false;
        private GameObject cameraWaveTrigger;

        private void Start() {
            for (int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        private void Update() {
            if (ongoing && transform.childCount == 0) {
                FinishWave();
                Destroy(gameObject); // no need for this game object anymore
            }                
        }

        private void FinishWave() {
            cameraWaveTrigger.SendMessage("UnlockCameraScroll");
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("CameraWaveTrigger")) {
                cameraWaveTrigger = other.transform.parent.gameObject;
                cameraWaveTrigger.SendMessage("LockCameraScroll");
                TriggerWave();
            }
        }

        private void TriggerWave() {
            ongoing = true;
            for (int i = 0; i < transform.childCount; i++) {
                transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
}
