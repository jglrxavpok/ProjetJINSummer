using System;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float gravity = -9.81f;
    public BoxCollider2D boxCollider;
    public float AXIS_DEADZONE = 0.1f;
    public float horizontalSpeed = 10f;
    public float jumpHeight = 10f;
    public Rigidbody2D rigidbody;
    private bool onGround = false;
    public Vector2 velocity = new Vector2();
    private int levelCollisionMaskLayer;
    public float collisionEpsilon = 0.0001f;

    // Start is called before the first frame update
    void Start()
    {
        levelCollisionMaskLayer = LayerMask.NameToLayer("LevelCollision");   
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        float mass = rigidbody.mass;

        if (onGround && Input.GetButton("Jump"))
        {
            float jumpForce = Mathf.Sqrt(2 * -gravity * jumpHeight);
            velocity.y = jumpForce;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float strafe = 0f;
        if (Math.Abs(horizontal) > AXIS_DEADZONE)
        {
            strafe = horizontal;
        }

        velocity.x = horizontalSpeed * strafe;
        velocity.y += gravity*dt;
        
        // step physics
        var previousPosition = transform.position;
        Vector2 position = new Vector2(previousPosition.x, previousPosition.y);

        // step X axis then Y axis
        position.x += step(position, ref velocity.x, dt, Vector2.right);
        position.y += step(position, ref velocity.y, dt, Vector2.up);

        rigidbody.MovePosition(position);
    }

    private float step(Vector2 startPosition, ref float velocity, float dt, Vector2 castDirection)
    {
        float displacement = velocity * dt;
        float possibleMovement = stepAxis(startPosition, displacement, castDirection);
        if ((Math.Abs(displacement) - possibleMovement) > 0)
        {
            // TODO: handle onGround
            velocity = possibleMovement/dt*Math.Sign(displacement);
            return possibleMovement*Math.Sign(displacement);
        }
        return displacement;
    }
    
    private float stepAxis(Vector2 startPosition, float displacement, Vector2 castDirection)
    {
        float closestDist = Math.Abs(displacement);
        // TODO: Use NonAlloc variant
        ContactFilter2D noFilter = new ContactFilter2D().NoFilter();
        foreach(var hit in Physics2D.BoxCastAll(startPosition+castDirection * (Math.Sign(displacement) * collisionEpsilon), boxCollider.size*transform.lossyScale, 0.0f, castDirection,
            displacement, noFilter.layerMask))
        {
            if (hit.collider && hit.collider.gameObject && hit.collider.gameObject != this.gameObject)
            {
                if (hit.distance < closestDist)
                {
                    closestDist = hit.distance;
                }
            }
        }

        return closestDist;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("LevelCollision"))
        {
            onGround = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("LevelCollision"))
        {
            onGround = false;
        }
    }
}
