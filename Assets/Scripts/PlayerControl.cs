using System;
using UnityEngine;

public class PlayerControl : PhysicsBase {
    public float AXIS_DEADZONE = 0.1f;
    public float horizontalSpeed = 10f;
    public float jumpHeight = 10f;

    void Update() {
        float mass = rigidbody.mass;

        if (onGround && Input.GetButton("Jump")) {
            float jumpForce = Mathf.Sqrt(2 * -gravity * jumpHeight);
            velocity.y = jumpForce;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float strafe = 0f;
        if (Math.Abs(horizontal) > AXIS_DEADZONE) {
            strafe = horizontal;
        }

        velocity.x = horizontalSpeed * strafe;

        base.Update();
    }
}
