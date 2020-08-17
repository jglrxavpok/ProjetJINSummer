using System;
using System.Linq;
using UnityEngine;

namespace JINSummer {
    
    [RequireComponent(typeof(Collider2D))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class Wave : MonoBehaviour {
        private bool ongoing = false;
        private GameObject cameraWaveTrigger;
        public bool blockCamera = true;

        private void Start() {
            GetComponent<Collider2D>().isTrigger = true; // force trigger
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
            if (blockCamera) {
                cameraWaveTrigger.SendMessage("UnlockCameraScroll");
            }
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("CameraWaveTrigger")) {
                cameraWaveTrigger = other.transform.parent.gameObject;
                if (blockCamera) {
                    cameraWaveTrigger.SendMessage("LockCameraScroll");
                }
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
