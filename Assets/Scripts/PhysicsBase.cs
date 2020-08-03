using UnityEngine;
using System;

public class PhysicsBase : MonoBehaviour {
    public float gravity = -9.81f;
    public BoxCollider2D boxCollider;
    public Rigidbody2D rigidbody;
    protected bool onGround = false;
    protected Vector2 velocity = new Vector2();
    public LayerMask levelCollisionMaskLayer;
    public float collisionEpsilon = 0.0001f;
    public float maxSlopeAngle = 50;
    public float stepEpsilon = 0.01f;
    private Vector2 position;

    private void Start() {
        position = transform.position;
    }

    // Update is called once per frame
    protected virtual void Update() {
        float dt = Time.deltaTime;
        velocity.y += gravity * dt;

        // step physics
        // step X axis then Y axis
        StepSlopes(ref position, ref velocity, dt);
        position.x += step(position, ref velocity.x, dt, Vector2.right);
        position.y += step(position, ref velocity.y, dt, Vector2.up);
    }

    private void FixedUpdate() {
        rigidbody.MovePosition(position);
    }

    /**
     * Step for slopes
     */
    private void StepSlopes(ref Vector2 position, ref Vector2 velocity, float dt) {
        if (Math.Abs(velocity.x) < collisionEpsilon) {
            return;
        }
        // idea from: https://www.youtube.com/watch?v=cwcC2tIKObU&list=PLFt_AvWsXl0f0hqURlhyIoAabKPgRsqjz&index=4
        float displacement = velocity.x*dt;
        Vector2 startPosition = position + Vector2.right * (Math.Sign(displacement) * collisionEpsilon);
        startPosition.x += (boxCollider.size.x*transform.lossyScale.x / 2.0f) * 0.99f * Math.Sign(displacement); // go to bottom of shape
        startPosition.y -= (boxCollider.size.y*transform.lossyScale.y / 2.0f) + stepEpsilon; // go to bottom of shape
        Debug.DrawLine(startPosition, startPosition + Vector2.right*displacement, Color.red);
        var hit = Physics2D.Raycast(startPosition, Vector2.right, displacement, levelCollisionMaskLayer.value);
        if (hit) {
            float slopeAngle = Vector2.Angle(hit.normal, Vector2.up);
            if (slopeAngle < maxSlopeAngle) {
                float d = Math.Abs(displacement);
                position.y += (float)(Math.Sin(Mathf.Deg2Rad * slopeAngle) * d);
            }
        }
    }

    private float step(Vector2 startPosition, ref float velocity, float dt, Vector2 castDirection) {
        float displacement = velocity * dt;
        float possibleMovement = stepAxis(startPosition, displacement, castDirection);
        if ((Math.Abs(displacement) - possibleMovement) > 0) {
            // TODO: handle onGround
            velocity = possibleMovement / dt * Math.Sign(displacement);
            return possibleMovement * Math.Sign(displacement);
        }

        return displacement;
    }

    private float stepAxis(Vector2 startPosition, float displacement, Vector2 castDirection) {
        float closestDist = Math.Abs(displacement);
        // TODO: Use NonAlloc variant
        foreach (var hit in Physics2D.BoxCastAll(
            startPosition + castDirection * (Math.Sign(displacement) * collisionEpsilon),
            boxCollider.size * transform.lossyScale, 0.0f, castDirection,
            displacement, levelCollisionMaskLayer.value)) {
            if (hit.collider && hit.collider.gameObject && hit.collider.gameObject != this.gameObject) {
                if (hit.distance < closestDist) {
                    closestDist = hit.distance;
                }
            }
        }

        return closestDist;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("LevelCollision")) {
            onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("LevelCollision")) {
            onGround = false;
        }
    }

    public void SetVelocity(float speedX, float speedY) {
        velocity.x = speedX;
        velocity.y = speedY;
    }

    public ref Vector2 GetVelocityRef() {
        return ref velocity;
    }
}
