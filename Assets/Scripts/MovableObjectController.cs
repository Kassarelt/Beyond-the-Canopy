using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectController : MonoBehaviour
{
    private float distToGround;
    
    private bool IsGrounded()
    {
        distToGround = GetComponent<Collider2D>().bounds.extents.y;
        RaycastHit2D ray;
        ray = Physics2D.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
        if (ray.collider != null && ray.collider.tag == "Platform") { return true; }
        else { return false; }
    }

    private void Update()
    {
        if (IsGrounded())
        {
            if (Player.isFpressed)
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
            else
            {
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
