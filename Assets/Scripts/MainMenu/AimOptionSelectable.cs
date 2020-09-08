using UnityEngine.UI;

namespace JINSummer.MainMenu {
    public class AimOptionSelectable : Selectable {
        private static string offText = "Use mouse to aim: <color=red>OFF</color>";
        private static string onText = "Use mouse to aim: <color=green>ON</color>";
        private Text text;

        private void Start() {
            text = GetComponent<Text>();
            UpdateText();
        }

        private void UpdateText() {
            text.text = Controls.UseMouseToAim ? onText : offText;
        }

        public override void OnSelected() {
            Controls.UseMouseToAim = !Controls.UseMouseToAim;
            UpdateText();
        }
    }
}
