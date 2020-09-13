using System;
using UnityEngine;

namespace JINSummer {
    public class MusicTrigger : MonoBehaviour {

        public AudioClip music;
        
        private void Start() {
            MusicPlayer.Instance.PlayMusic("Music/"+music.name);
        }
    }
}
