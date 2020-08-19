using System;
using JINSummer.Math;
using UnityEngine;

namespace JINSummer {
    [RequireComponent(typeof(Camera))]
    public class CameraFollowPath : MonoBehaviour {
        public LineRenderer pathProvider;
        public GameObject player;
        public float lerpSpeed = 1.0f;

        private Vector2 position;
        private Vector2[] path;
        private float startZ;

        // prevents back-tracking
        private float maxX;

        // used by waves to stop scroll
        private bool locked = false;

        private void Start() {
            maxX = transform.position.x;
            startZ = transform.position.z;
            path = new Vector2[pathProvider.positionCount];
            for (int i = 0; i < path.Length; i++) {
                Vector3 pos = pathProvider.GetPosition(i)+pathProvider.transform.position;
                path[i] = new Vector2(pos.x, pos.y);
            }
        }

        /// <summary>
        /// Projects to the closest point on camera path
        /// </summary>
        /// <param name="point"></param>
        private Vector2? ProjectOnPath(Vector2 point) {
            Vector2? closest = null;
            float distance = float.PositiveInfinity;
            for (int i = 0; i < path.Length-1; i++) {
                Vector2 start = path[i];
                Vector2 end = path[i + 1];
                
                Vector2 direction = end - start;
                Vector2 start2point = point - start;
                float progressAlongSegment = Vector2.Dot(start2point, direction) / (direction.sqrMagnitude);
                Vector2 perpendicularProjection = start + direction * progressAlongSegment;

                // projection must be on segment
                if (progressAlongSegment < 0f || progressAlongSegment > 1.0f) {
                    continue;
                }
                
                float sqPerpendicularDistance = (perpendicularProjection - point).sqrMagnitude;
                if (sqPerpendicularDistance < distance) {
                    distance = sqPerpendicularDistance;
                    closest = perpendicularProjection;
                }
            }

            return closest;
        }

        private void Update() {
            if (locked)
                return;
            Vector2 playerPos = player.transform.position;
            
            Vector2? positionOnPath = ProjectOnPath(playerPos);
            if (positionOnPath != null) { // update only if on path
                var pos = positionOnPath.Value;
                Debug.DrawLine(pos+Vector2.up, pos-Vector2.up);
                Debug.DrawLine(playerPos, pos, Color.blue);
                position = new Vector3(pos.x, pos.y, startZ);
            }

            float timeDilatation = Time.deltaTime; // ensure lerp speed is consistent even with varying framerate
            Vector3 finalCameraPosition = Vector2.Lerp(transform.position, position, 1.0f/lerpSpeed * timeDilatation*60.0f);
            if (finalCameraPosition.x < maxX) {
                // don't move camera
                return;
            }

            finalCameraPosition.z = startZ;
            transform.position = finalCameraPosition;
            maxX = finalCameraPosition.x;
        }

        public void LockCameraScroll() {
            locked = true;
        }
        
        public void UnlockCameraScroll() {
            locked = false;
        }
    }
}
