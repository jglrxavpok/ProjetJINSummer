using UnityEngine;
using UnityEngine.UI;

namespace JINSummer {
    
    /// <summary>
    /// Uses 2 health points per heart
    /// </summary>
    public class HealthBar : MonoBehaviour {
        public Animator[] hearts;

        public int currentHealth = 11;
        private static readonly int Full = Animator.StringToHash("Full");
        private static readonly int Half = Animator.StringToHash("Half");

        public void Start() {
            SetHealth(currentHealth);
        }
        
        public void SetHealth(int value) {
            bool willHaveHalfHeart = value % 2 == 1;
            int heartCount = value / 2;
            for (int i = 0; i < hearts.Length; i++) {
                if (i < heartCount) { // full
                    hearts[i].SetBool(Full, true);
                } else { // empty
                    hearts[i].SetBool(Full, false);
                }
                hearts[heartCount].SetBool(Half, false);
            }

            hearts[heartCount].SetBool(Half, true);
        }

    }
}
