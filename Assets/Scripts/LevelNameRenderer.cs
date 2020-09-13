using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace JINSummer {
    public class LevelNameRenderer : MonoBehaviour {
        private void Start() {
            GetComponent<Text>().text = SceneManager.GetActiveScene().name;
        }
    }
}
