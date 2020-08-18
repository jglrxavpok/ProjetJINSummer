using UnityEngine;

namespace JINSummer.MainMenu {
    
    [RequireComponent(typeof(RectTransform))]
    public abstract class Selectable : MonoBehaviour {
        
        public abstract void OnSelected();
    }
}