using System;
using UnityEngine;

namespace JINSummer {
    [RequireComponent(typeof(AudioSource))]
    public class MusicPlayer : MonoBehaviour {

        private static MusicPlayer instance = null;

        public static MusicPlayer Instance => instance;
        private static string currentMusic;
        
        private AudioSource audioSource;
        
        
        private void Awake() {
            if (instance != null && instance != this) {
                Destroy(gameObject);
                return;
            }

            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayMusic(string music) {
            if (currentMusic != music) {
                audioSource.Stop();
                AudioClip musicClip = Resources.Load<AudioClip>(music);
                if (musicClip != null) {
                    audioSource.clip = musicClip;
                    audioSource.Play();
                } else {
                    Debug.LogError("Failed to load music: "+music);
                }

                currentMusic = music;
            }
        }
    }
}
