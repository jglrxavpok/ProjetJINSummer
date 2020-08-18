using UnityEngine;

namespace JINSummer.MainMenu {
    public class PlaceholderSelectable : Selectable {
        public override void OnSelected() {
            print("I was selected but I don't do anything!");
        }
    }
}