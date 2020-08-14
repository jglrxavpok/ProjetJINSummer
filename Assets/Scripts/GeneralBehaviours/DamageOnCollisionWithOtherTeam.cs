using System;
using UnityEngine;

namespace JINSummer.GeneralBehaviours {
    public class DamageOnCollisionWithOtherTeam : MonoBehaviour {
        public TeamParticipant team;
        public int damage = 1; // 1/2 heart by default

        public void OnCollisionEnter2D(Collision2D other) {
            GameObject otherObject = other.gameObject;
            TeamParticipant otherParticipant = otherObject.GetComponent<TeamParticipant>();
            if (otherParticipant) {
                if (otherParticipant.GetTeam().OnOpposingTeam(team.GetTeam())) {
                    Destroy(gameObject);
                    HealthSystem health = otherObject.GetComponent<HealthSystem>();
                    health.Damage(damage);
                }
            }
        }
    }
}
