using JINSummer;
using UnityEngine;

public abstract class Aim : MonoBehaviour {
    protected AimDirection direction = AimDirection.RIGHT;

    public AimDirection GetDirection() {
        return direction;
    }
}
