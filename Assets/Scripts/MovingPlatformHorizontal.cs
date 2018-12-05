using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformHorizontal : MonoBehaviour
{

    public float min;
    public float max;
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (transform.position.x < min && speed < 0)
        {
            speed *= -1;
        }
        if (transform.position.x > max && speed > 0)
        {
            speed *= -1;
        }

        // Get top of platform
        Bounds bounds = GetComponent<SpriteRenderer>().bounds;
        Vector2 topLeft = new Vector2(bounds.center.x - (bounds.size.x / 2), bounds.center.y + (bounds.size.y / 2) + 0.1f);

        RaycastHit2D[] objectsOnPlatform = Physics2D.RaycastAll(topLeft, new Vector2(bounds.size.x, 0));

        // Move platform
        transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);

        foreach (RaycastHit2D hit in objectsOnPlatform)
        {
            if (hit.collider.gameObject.tag == "Player" && hit.distance <= bounds.size.x)
            {
                Transform otherObjectPosition = hit.collider.gameObject.transform;
                otherObjectPosition.position = new Vector3(otherObjectPosition.position.x + speed * Time.deltaTime, otherObjectPosition.position.y, otherObjectPosition.position.z);
            }
       }
    }

}
