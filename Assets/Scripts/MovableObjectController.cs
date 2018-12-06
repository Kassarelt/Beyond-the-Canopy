using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectController : MonoBehaviour
{
    private float distToGround;
    
    // Check if MovableObject is grounded
    private bool IsGrounded()
    {
        // Get distance to ground
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        RaycastHit2D ray;
        ray = Physics2D.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
        return ray.collider != null && ray.collider.tag == "Platform";
    }

    private void Update()
    {
        if (IsGrounded())
        {
            if (Player.isFpressed)
            {
                // If movable object is grounded and player have clicked on F then movableObject isn't movable
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            else
            {
                // If movable object is grounded and player don't have clicked on F then movableObject isn't movable
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
        else
        {
            // If player isn't grounded then gravity isn't modulate for player
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
