using System;
using UnityEngine;

namespace JINSummer.GeneralBehaviours {
    public class HealPlayer : MonoBehaviour {

        public int healAmount = 2; // 1 is half a heart
        
        private void OnTriggerEnter2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                other.GetComponent<HealthSystem>().Heal(healAmount);
                Destroy(gameObject);
            }
        }
    }
}
