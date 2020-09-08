using System;
using UnityEngine;

namespace JINSummer.MainMenu {
    public class Selector : MonoBehaviour {
        public Selectable[] items;
        public float AXIS_DEADZONE = 0.35f;
        public Vector2 offset = new Vector2();
        public float cooldownBeforeSwitch = 0.5f;
        
        private float cooldown = 0.0f;
        private Selectable selected;
        private int index = 0;
        private Vector3[] corners = {new Vector3(),new Vector3(),new Vector3(),new Vector3()};

        private void Start() {
            selected = items[0];
            ComputePosition();
        }

        private void ComputePosition() {
            RectTransform selectableTransform = selected.GetComponent<RectTransform>();
            selectableTransform.GetWorldCorners(corners);
            Vector3 bottomLeft = corners[0];
            Vector3 topLeft = corners[1];
            Vector3 position = (bottomLeft + topLeft) / 2;
            position.x += offset.x;
            position.y += offset.y;
            transform.position = position;
        }

        public void Update() {
            if (cooldown > 0f) {
                cooldown -= Time.deltaTime;
                return;
            }
            
            if (Input.GetAxis("Vertical") < -AXIS_DEADZONE) {
                cooldown = cooldownBeforeSwitch;
                index++;
                if (index >= items.Length) {
                    index = 0;
                }
                UpdateSelection();
            } else if (Input.GetAxis("Vertical") > AXIS_DEADZONE) {
                cooldown = cooldownBeforeSwitch;
                index--;
                if (index < 0) {
                    index = items.Length - 1;
                }
                UpdateSelection();
            }
            if (Input.GetButtonDown("Submit")) {
                selected.OnSelected();
            }
        }

        private void UpdateSelection() {
            selected = items[index];
            ComputePosition();
        }
    }
    
}