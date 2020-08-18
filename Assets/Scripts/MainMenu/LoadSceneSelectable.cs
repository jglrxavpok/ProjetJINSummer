using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JINSummer.MainMenu {
    public class LoadSceneSelectable : Selectable {

        public String toLoad;

        public override void OnSelected() {
            SceneManager.LoadScene(toLoad);
        }
    }
}