using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformVertical : MonoBehaviour
{

    public float min;
    public float max;
    public float speed;

    // Update is called once per frame
    void Update()
    {

        if (transform.position.y < min && speed < 0)
        {
            speed *= -1;
        }
        if (transform.position.y > max && speed > 0)
        {
            speed *= -1;
        }

        // Get top of platform
        Bounds bounds = GetComponent<SpriteRenderer>().bounds;
        Vector2 topLeft = new Vector2(bounds.center.x - (bounds.size.x / 2), bounds.center.y + (bounds.size.y / 2) + 0.1f);

        // Create a raycast at top of platform
        RaycastHit2D[] objectsOnPlatform = Physics2D.RaycastAll(topLeft, new Vector2(bounds.size.x, 0));

        // Move platform
        transform.position = new Vector3(transform.position.x, transform.position.y + speed * Time.deltaTime, transform.position.z);

        // Move objects on platforms
        foreach (RaycastHit2D hit in objectsOnPlatform)
        {
            // For moment only player could be on platform so we move only the player
            if (hit.collider.gameObject.tag == "Player" && hit.distance <= bounds.size.x)
            {
                Transform otherObjectPosition = hit.collider.gameObject.transform;
                otherObjectPosition.position = new Vector3(otherObjectPosition.position.x, otherObjectPosition.position.y + speed * Time.deltaTime, transform.position.z);
            }
        }
    }

}
