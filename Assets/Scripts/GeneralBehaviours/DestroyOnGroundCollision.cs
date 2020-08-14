using UnityEngine;

namespace JINSummer.GeneralBehaviours {
    public class DestroyOnGroundCollision : MonoBehaviour {
        public void OnCollisionEnter2D(Collision2D other) {
            if (other.gameObject.CompareTag("LevelCollision")) {
                Destroy(gameObject);
            }
        }
    }
}
