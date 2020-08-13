using System;
using UnityEngine;

namespace JINSummer.GeneralBehaviours {
    public class KillOffscreen : MonoBehaviour {

        public float margin = 100f;
        private Camera _camera;

        private void Start() {
            _camera = Camera.main;
        }

        public void Update() {
            Vector3 screenPosition = _camera.WorldToScreenPoint(transform.position);
            if (screenPosition.x < -margin 
                || screenPosition.x >= Screen.width + margin 
                || screenPosition.y < -margin 
                || screenPosition.y >= Screen.height + margin) {
                Destroy(gameObject); // kill parent
            }
        }
    }
}
