using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float movementSpeed = 4.0f;
    public float jumpPower = 7.0f;
    public bool activateSlide = false;

    private bool isOnPlatform = false;
    private Rigidbody2D myBody;

    // Use this for initialization
    void Start () {
        myBody = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        // Go left
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            myBody.velocity = new Vector2(myBody.velocity.x - movementSpeed, myBody.velocity.y);
            if (myBody.velocity.x < -movementSpeed)
            {
                myBody.velocity = new Vector2(-movementSpeed, myBody.velocity.y);
            }
        }
        // Go right
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            myBody.velocity = new Vector2(myBody.velocity.y + movementSpeed, myBody.velocity.y);
            if (myBody.velocity.x > movementSpeed)
            {
                myBody.velocity = new Vector2(movementSpeed, myBody.velocity.y);
            }
        }
        // Slide management
        else if (myBody.velocity.y < 1 && !activateSlide)
        {
            myBody.velocity = new Vector2(myBody.velocity.x * 0, myBody.velocity.y);
        }

        //Debug.Log(isOnPlatform);
        if (Input.GetKey(KeyCode.Space) && isOnPlatform)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);
        }
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.gameObject.tag == "Platform")
        {
            Debug.Log("test");
            isOnPlatform = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Platform")
        {
            isOnPlatform = false;
        }
    }
}
