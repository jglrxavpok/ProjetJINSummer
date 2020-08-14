using UnityEngine;

namespace JINSummer {
    public class TeamParticipant : MonoBehaviour {
        [SerializeField]
        private Team team;

        public Team GetTeam() {
            return team;
        }
    }
}
