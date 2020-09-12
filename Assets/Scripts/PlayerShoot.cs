using System;
using UnityEngine;

namespace JINSummer {
    public class PlayerShoot : Shoot {

        private AudioSource source;
        public AudioClip shootSound;

        private void Start() {
            source = GetComponent<AudioSource>();
        }

        protected override bool ShouldShoot() {
            return Input.GetAxis("Shoot") > 0.1;
        }

        protected override void SpawnBullet(float angle, float speedX, float speedY) {
            source.PlayOneShot(shootSound, AudioListener.volume);
            base.SpawnBullet(angle, speedX, speedY);
        }
    }
}
