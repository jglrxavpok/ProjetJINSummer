using System;
using JINSummer;
using UnityEngine;

public class AimPlayerControl : Aim {

    // used for debug
    public Vector2 aimVector;
    /**
     * Camera used to calculate mouse position in world space
     */
    public Camera camera;

    public void Update() {
        float aimX = Input.GetAxis("Aim X");
        float aimY = Input.GetAxis("Aim Y");
        // no gamepad
        if (Input.GetJoystickNames().Length == 0) {
            Vector3 mouseInWorld = camera.ScreenToWorldPoint(Input.mousePosition);
            aimX = mouseInWorld.x - transform.position.x;
            aimY = mouseInWorld.y - transform.position.y;
        }
        
        aimVector.x = aimX;
        aimVector.y = aimY;

        AimDirection aimDirection = aimVector.ClosestDirection();
        if (aimDirection != AimDirection.LAST) {
            direction = aimDirection;    
        }
    }
}
