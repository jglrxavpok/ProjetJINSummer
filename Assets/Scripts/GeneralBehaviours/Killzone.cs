using System;
using UnityEngine;

namespace JINSummer.GeneralBehaviours {
    public class Killzone : MonoBehaviour {
        private void OnTriggerEnter2D(Collider2D other) {
            HealthSystem health = other.gameObject.GetComponent<HealthSystem>();
            if (health != null) {
                health.Damage(health.GetMaxHealth());
            }
        }
    }
}
