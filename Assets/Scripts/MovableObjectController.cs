using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjectController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.tag == "Platform")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        if (collision.gameObject.tag == "movablePlatform")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.tag == "Platform")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
        if (collision.gameObject.tag == "movablePlatform")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player" && collision.gameObject.tag == "Platform")
        {
            GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
