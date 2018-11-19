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
    private Rigidbody2D body;
    private Animator anim;
    public bool isGrounded = false;
    //public bool doubleJump = false;
    public Transform spaceShip;
    Transform groundCheck;


    Vector2 touchedPosition;
    bool isCollected = false;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundCheck = GameObject.Find("groundCheck").transform;
    }
    private float lerpTime = 5;
    private float currentLerpTime=0;
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
        //doubleJump = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
        float speed = Input.GetAxis("Horizontal") * MaxSpeed;
        // anim.SetFloat("xSpeed", Mathf.Abs(speed));
        if (!isCollected)
        {
            body.velocity = new Vector2(speed, body.velocity.y);
        }
        
       // anim.SetFloat("ySpeed", body.velocity.y);
       
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
    //   public float movementSpeed = 4.0f;
    //   public float jumpPower = 7.0f;
    //   public bool activateSlide = false;

    //   private bool isOnPlatform = false;
    //   private Rigidbody2D myBody;

    //   // Use this for initialization
    //   void Start () {
    //       myBody = gameObject.GetComponent<Rigidbody2D>();
    //   }

    //// Update is called once per frame
    //void Update () {
    //       // Go left
    //       if (Input.GetKey(KeyCode.LeftArrow))
    //       {
    //           myBody.velocity = new Vector2(myBody.velocity.x - movementSpeed, myBody.velocity.y);
    //           if (myBody.velocity.x < -movementSpeed)
    //           {
    //               myBody.velocity = new Vector2(-movementSpeed, myBody.velocity.y);
    //           }
    //       }
    //       // Go right
    //       else if (Input.GetKey(KeyCode.RightArrow))
    //       {
    //           myBody.velocity = new Vector2(myBody.velocity.y + movementSpeed, myBody.velocity.y);
    //           if (myBody.velocity.x > movementSpeed)
    //           {
    //               myBody.velocity = new Vector2(movementSpeed, myBody.velocity.y);
    //           }
    //       }
    //       // Slide management
    //       else if (myBody.velocity.y < 1 && !activateSlide)
    //       {
    //           myBody.velocity = new Vector2(myBody.velocity.x * 0, myBody.velocity.y);
    //       }

    //       //Debug.Log(isOnPlatform);
    //       if (Input.GetKey(KeyCode.Space) && isOnPlatform)
    //       {
    //           myBody.velocity = new Vector2(myBody.velocity.x, jumpPower);
    //       }

    //   }

    //   private void OnCollisionEnter2D(Collision2D other)
    //   {

    //       if (other.gameObject.tag == "Platform")
    //       {
    //           Debug.Log("test");
    //           isOnPlatform = true;
    //       }
    //   }

    //   private void OnCollisionExit2D(Collision2D other)
    //   {
    //       if (other.gameObject.tag == "Platform")
    //       {
    //           isOnPlatform = false;
    //       }
    //   }
}
