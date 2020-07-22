using UnityEngine;

public class AutoResizeSprite : MonoBehaviour {
    public void Start() {
        Vector3 parentSize = transform.parent.lossyScale;
        transform.localScale = new Vector3(1.0f / parentSize.x, 1.0f / parentSize.y, 1.0f / parentSize.z) * 2.0f;
    }
}
