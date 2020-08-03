using System;
using JINSummer.PlayerStates;
using UnityEngine;

public class PlayerControl : PhysicsBase {
    public float AXIS_DEADZONE = 0.1f;
    public float horizontalSpeed = 10f;
    public float jumpHeight = 10f;
    private PlayerState currentState = IdleState.Instance();

    protected override void Update() {
        float mass = rigidbody.mass;

        if (currentState.AllowJumping() && Input.GetButton("Jump")) {
            float jumpForce = Mathf.Sqrt(2 * -gravity * jumpHeight);
            velocity.y = jumpForce;
            SetState(JumpingState.Instance());
        }

        if (!onGround && velocity.y < 0) {
            SetState(FallingState.Instance());
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float strafe = 0f;
        bool applyGroundFriction = true;
        if (Math.Abs(horizontal) > AXIS_DEADZONE) {
            if (currentState.AllowRunning()) {
                strafe = horizontal;
                SetState(RunningState.Instance());
                
                velocity.x = horizontalSpeed * strafe;
                applyGroundFriction = false;
                // TODO: Air control?
            }
        }
        
        if (currentState.AllowCrouching() && vertical < -AXIS_DEADZONE) {
            SetState(CrouchingState.Instance());
        } else if (strafe == 0f && onGround) {
            SetState(IdleState.Instance());
        }

        if (applyGroundFriction) {
            if (onGround) {
                velocity.x *= 0.85f;
            } else {
                velocity.x *= 0.999f;
            }
        }
        
        print(Time.deltaTime);

        currentState.Update(gameObject, this);
        // TODO: Friction/Drag

        base.Update();
    }

    private void SetState(PlayerState newState) {
        if (newState == currentState) {
            return;
        }

        currentState.TransitionOut(gameObject, this);
        currentState = newState;
        newState.TransitionIn(gameObject, this);
    }
}
