using System;
using UnityEngine;

namespace JINSummer.GeneralBehaviours {
    public class HealthSystem : MonoBehaviour {
        public HealthBar healthBar; // visual representation, optional
        private int currentHealth;

        [SerializeField]
        private int maxHealth = 10; // 5 hearts

        public void Start() {
            currentHealth = maxHealth;
            UpdateHealthBar();
        }

        private void UpdateHealthBar() {
            if (healthBar) {
                healthBar.SetHealth(currentHealth);
            }
        }

        private void CheckBounds() {
            if (currentHealth > maxHealth) {
                currentHealth = maxHealth;
            }

            if (currentHealth <= 0) {
                Destroy(gameObject); // TODO: other option for player
            }
        }

        public void Heal(int amount) {
            currentHealth += amount;
            CheckBounds();
            UpdateHealthBar();
        }

        public void Damage(int amount) {
            currentHealth -= amount;
            CheckBounds();
            UpdateHealthBar();
        }

        public int GetHealth() {
            return currentHealth;
        }

        public int GetMaxHealth() {
            return maxHealth;
        }
    }
}
