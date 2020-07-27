using System;
using UnityEngine;

namespace JINSummer {
    public class Shoot : MonoBehaviour {

        public Aim aim;
        
        // TODO: Different weapons?
        // TODO: Pooled
        public GameObject bullet;
        public float speed = 10.0f;

        public void Update() {
            if (Input.GetButton("Shoot")) {
                AimDirection direction = aim.GetDirection();
                float angle = direction.Angle();
                float cosangle = Mathf.Cos(angle);
                float sinangle = Mathf.Sin(angle);
                SpawnBullet(angle, cosangle*speed, sinangle*speed);

                // TODO: cooldown
            }
        }

        private void SpawnBullet(float angle, float speedX, float speedY) {
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = transform.position;
            newBullet.transform.rotation = Quaternion.Euler(0,0,angle);
            PhysicsBase physics = newBullet.GetComponent<PhysicsBase>();
            physics.SetVelocity(speedX, speedY);
        }
    }
}
