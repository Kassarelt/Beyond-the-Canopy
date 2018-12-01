using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTimer : MonoBehaviour {

    public float timeOfLevel = 10f;
    public Slider timeBar;
    [Range(0, 2f)]
    public float timeSpeed;
    [Range(0,0.5f)]
    public float spikeDamage;
    [Range(0, 0.5f)]
    public float lavaDamage;

    public SceneTransitionMenu sceneManager;

    private Player playerMoveScript;
    private bool wasGrounded = true;
    public float fallDamage;
    public float velocityFallMax;


    // Variable to check ground
    public bool isGrounded;
    public float groundCheckRadius = 0.1f;
    public LayerMask WhatIsGround;
    private Transform groundCheck;

    // Use this for initialization
    void Start () {
        playerMoveScript = gameObject.GetComponent<Player>();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        fallDmg();
        TimeCounter();
    }

    void fallDmg()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
        if (!wasGrounded && isGrounded && gameObject.GetComponent<Rigidbody2D>().velocity.y > velocityFallMax)
        {
            timeBar.value -= fallDamage * (gameObject.GetComponent<Rigidbody2D>().velocity.y - velocityFallMax);
        }
    }

    void TimeCounter()
    {
        if (timeBar.value >= 0)
        {
            timeBar.value -= (timeSpeed / 10) * Time.deltaTime;

            if (timeBar.value == 0)
            {
                //UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
                //SceneTransitionMenu scene = new SceneTransitionMenu();
                //scene.Reload();
                sceneManager.Reload();
            }
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            timeBar.value -= spikeDamage;
        }
        if (collision.gameObject.tag == "Lava")
        {
            timeBar.value -= lavaDamage;
        }
    }
}
