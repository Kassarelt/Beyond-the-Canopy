using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Varibale for movements (Move + Jump)
    public float MaxSpeed = 5f;
    public float JumpForce = 200f;
    //private float DoubleJumpForce = 200f;
    //public bool doubleJump = false;
    public float groundCheckRadius = 0.05f;

    private Rigidbody2D body;

    // Variable to check if left or right
    private bool facingRight = false;
   
    // Variable to check ground
    public bool isGrounded = false;
    public LayerMask WhatIsGround;

    private Transform groundCheck;

    // Variable for Spaceship
    public Transform spaceShip;

    // Variable of Animators
    private Animator playerAnim;
    private Animator dastAnim;

    // Variable to check if object has been collected and to play on time
    private Vector2 touchedPosition;
    public bool isCollected = false;
    private float lerpTime = 5;
    private float currentLerpTime = 0;

    // Varibale for move Objects
    private float distanceToBottomOfPlayer = 0.8f;
    private GameObject lockedObject = null;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        groundCheck = GameObject.Find("groundCheck").transform;
        dastAnim = GameObject.Find("dast").GetComponent<Animator>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
        //doubleJump = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
        // Movement
        float speed = Input.GetAxis("Horizontal") * MaxSpeed;
        if (lockedObject != null)
        {
            speed /= 2;
        }
        if (!isCollected)
        {
            body.velocity = new Vector2(speed, body.velocity.y);
        }


        // ANIMATION
        playerAnim.SetBool("isGrounded", isGrounded);
        dastAnim.SetBool("isGrounded", isGrounded);

        if (speed != 0)
        {
            playerAnim.SetBool("isWalking", true);
            dastAnim.SetBool("isWalking", true);
        }
        else
        {
            playerAnim.SetBool("isWalking", false);
            dastAnim.SetBool("isWalking", false);
        }

        // Move OBJECT
        if (Input.GetKeyDown(KeyCode.F) && isGrounded && !isCollected)
        {
            Debug.Log("Down");
            RaycastHit2D ray;
            if (facingRight)
            {
                ray = Physics2D.Raycast(transform.position, Vector2.right);
            }
            else
            {
                ray = Physics2D.Raycast(transform.position, Vector2.left);
            }
            if (ray.collider != null && ray.collider.tag == "movableObject" && ray.distance < distanceToBottomOfPlayer)
            {
                lockedObject = ray.collider.gameObject;
                lockedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
        if (Input.GetKeyUp(KeyCode.F) && isGrounded && !isCollected)
        {
            lockedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            lockedObject = null;
        }
        if (!isCollected && lockedObject != null)
        {
            lockedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, lockedObject.GetComponent<Rigidbody2D>().velocity.y);
        }


        // JUMP
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isCollected && lockedObject == null)
        {
            body.AddForce(new Vector2(0, JumpForce));
           // doubleJump = true;
        }
        //else if (Input.GetButtonDown("Jump") && doubleJump)
        //{
        //    body.AddForce(new Vector2(0, DoubleJumpForce));
        //    anim.SetTrigger("Jump");
        //    doubleJump = false;
        //}

        // Code end of level (play small animation
        if (isCollected && (transform.position != spaceShip.position))
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<SpriteRenderer>().sortingLayerName = "BeforePlayer";
            GetComponent<SpriteRenderer>().sortingOrder = 10;
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime>=lerpTime)
            {
                currentLerpTime = lerpTime;
                SceneController myScene = new SceneController();
                myScene.SceneShifter(2);
            }
            float Perc = currentLerpTime / lerpTime;
            transform.position = Vector3.Lerp(touchedPosition,spaceShip.position,Perc);
        }

        // Flip the player when require
        if ((speed > 0 && !facingRight) || (speed < 0 && facingRight))
        {
            Flip();
        }
    }
    
    private void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-1 * transform.localScale.x, 1, 1);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //When the player grab the ore
        if (other.gameObject.tag == "TheOre")
        {
            Destroy(other.gameObject);
            touchedPosition = transform.position;
            isCollected = true;
        }
        //When the player falls down
        if (other.gameObject.tag == "DeepGround")
        {
            SceneController scene = new SceneController();
            Destroy(gameObject);
            scene.SceneShifter(1);
        }
    }
}
