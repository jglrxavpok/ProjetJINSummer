using UnityEngine;

namespace JINSummer.MainMenu {
    public class QuitGameSelectable : Selectable {
        public override void OnSelected() {
            Application.Quit();
        }
    }
}
