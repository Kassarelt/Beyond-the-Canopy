using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MaxSpeed = 5f;
    public float JumpForce = 200f;
    private float DoubleJumpForce = 200f;
    public float groundCheckRadius = 0.05f;
    public LayerMask WhatIsGround;
    private bool facingRight = false;
   
    public bool isGrounded = false;
    //public bool doubleJump = false;
    public Transform spaceShip;

    private Rigidbody2D body;
    private Animator playerAnim;
    private Animator dastAnim;

    Transform groundCheck;


    Vector2 touchedPosition;
    bool isCollected = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        groundCheck = GameObject.Find("groundCheck").transform;
        dastAnim = GameObject.Find("dast").GetComponent<Animator>();
    }

    private float lerpTime = 5;
    private float currentLerpTime=0;

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
        //doubleJump = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
        float speed = Input.GetAxis("Horizontal") * MaxSpeed;

        if (!isCollected)
        {
            body.velocity = new Vector2(speed, body.velocity.y);
        }

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

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isCollected)
        {
            //Debug.Log("Jump " + JumpForce + isGrounded);


            body.AddForce(new Vector2(0, JumpForce));
           // anim.SetTrigger("Jump");
           // doubleJump = true;
        }
        //else if (Input.GetButtonDown("Jump") && doubleJump)
        //{
        //    body.AddForce(new Vector2(0, DoubleJumpForce));
        //    anim.SetTrigger("Jump");
        //    doubleJump = false;
        //}

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
        if (other.gameObject.tag == "TheOre")
        {
            Destroy(other.gameObject);
            touchedPosition = transform.position;
            isCollected = true;
        }
    }
}
