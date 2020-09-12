using System;
using UnityEngine;

namespace JINSummer {
    public class Shoot : MonoBehaviour {

        public Aim aim;
        
        // TODO: Different weapons?
        // TODO: Pooled
        public GameObject bullet;
        public float speed = 10.0f;
        private float cooldown = 0.0f;
        public float shootCooldown = 0.2f;

        public void Update() {
            if (cooldown > 0) {
                cooldown -= Time.deltaTime;                
            }
            if (ShouldShoot() && CanShoot()) {
                AimDirection direction = aim.GetDirection();
                float angle = direction.Angle();
                float cosangle = Mathf.Cos(angle);
                float sinangle = Mathf.Sin(angle);
                SpawnBullet(angle, cosangle*speed, sinangle*speed);
                cooldown = shootCooldown;
            }
        }

        protected virtual bool ShouldShoot() {
            return true;
        }

        private bool CanShoot() {
            return cooldown <= 0f;
        }

        protected virtual void SpawnBullet(float angle, float speedX, float speedY) {
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = transform.position;
            newBullet.transform.rotation = Quaternion.Euler(0,0,angle);
            PhysicsBase physics = newBullet.GetComponent<PhysicsBase>();
            physics.SetVelocity(speedX, speedY);
        }
    }
}
