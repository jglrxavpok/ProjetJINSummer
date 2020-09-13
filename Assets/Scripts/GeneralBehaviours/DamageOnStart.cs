using System;
using UnityEngine;

namespace JINSummer.GeneralBehaviours {
    [RequireComponent(typeof(HealthSystem))]
    public class DamageOnStart : MonoBehaviour {
        public int amount;

        private void Update() {
            // not called in Start to ensure the health system has been initialized
            HealthSystem healthSystem = GetComponent<HealthSystem>();
            healthSystem.Damage(amount);
            Destroy(this);
        }
    }
}
