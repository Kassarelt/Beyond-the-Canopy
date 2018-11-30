using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavesFadeInAndOut : MonoBehaviour {

    private Animator transitionAnim;

	// Use this for initialization
	void Start () {
        transitionAnim = gameObject.GetComponent<Animator>();
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            transitionAnim.SetTrigger("enter");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            transitionAnim.SetTrigger("enter");
        }
    }
}
