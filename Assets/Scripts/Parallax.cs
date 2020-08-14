using System;
using UnityEngine;

namespace JINSummer {
    public class Parallax : MonoBehaviour {
        private Camera _camera;
        public float positionDivider = 3f;

        private void Start() {
            _camera = Camera.main;
        }

        private void Update() {
            transform.position = _camera.transform.position/positionDivider;
        }
    }
}
