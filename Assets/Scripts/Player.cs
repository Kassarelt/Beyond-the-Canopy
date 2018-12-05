using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Varibale for movements (Move + Jump)
    public float MaxSpeed = 5f;
    public float JumpForce = 200f;
    //private float DoubleJumpForce = 200f;
    //public bool doubleJump = false;
    public float groundCheckRadius = 0.1f;

    private Rigidbody2D body;

    // Variable to check if left or right
    private bool facingRight = false;
   
    // Variable to check ground
    public bool isGrounded = false;
    public LayerMask WhatIsGround;
    private Transform groundCheck;

    //Cluster for particle effect
    public GameObject walkingEffect;
    public GameObject jumpEffect;
    private Vector2 effectPos;

    // Variable of Animators
    private Animator playerAnim;
    //private Animator dastAnim;

    // Variable to check if object has been collected and to play on time
    public GameObject itemUI;
    public int maxItems;
    private int countItems = 0;
    
    // Variable for move Objects
    private float distanceToBottomOfPlayer = 7f;
    private GameObject lockedObject = null;
    public static bool isFpressed = false;

    public float distanceToSides = 7f;

    // Variables for sound effects
    private AudioSource audioSource;
    public AudioClip walkingSound;
    public AudioClip jumpingSound;
    public AudioClip collectingSound;
    public AudioClip victorySound;

    // GameManager access
    private GameManager manager;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        body = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<Animator>();
        groundCheck = GameObject.Find("groundCheck").transform;

        manager = GameObject.FindObjectOfType<GameManager>();

       // dastAnim = GameObject.Find("dast").GetComponent<Animator>();

       // itemUI.GetComponent<Text>().text = countItems + "/" + maxItems;
        
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
        //doubleJump = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);


        //walking effect management
        effectPos = new Vector2(transform.position.x, transform.position.y - 3.9f);
        //instantiating the walking effect
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)) && isGrounded)
        {
            audioSource.PlayOneShot(walkingSound);
            Instantiate(walkingEffect, effectPos, Quaternion.Euler(180, 0, 180));
        }
        else if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)) && isGrounded)
        {
            audioSource.PlayOneShot(walkingSound);
            Instantiate(walkingEffect, effectPos, Quaternion.Euler(0, 0, 0));
        }

        // Movement
        float speed = Input.GetAxis("Horizontal") * MaxSpeed;
        if (lockedObject != null)
        {
            speed /= 2;
        }
        //if (!isCollected)
        //{
            body.velocity = new Vector2(speed, body.velocity.y);
        //}


        // ANIMATION
        playerAnim.SetBool("isGrounded", isGrounded);

        if (speed != 0)
        {
            playerAnim.SetBool("isWalking", true);
        }
        else
        {
            playerAnim.SetBool("isWalking", false);
        }

        // Move OBJECT
        if (Input.GetKeyDown(KeyCode.F) && isGrounded /*&& !isCollected*/)
        {
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
                playerAnim.SetBool("isPulling", true);
                lockedObject = ray.collider.gameObject;
                isFpressed = true;
                //lockedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            }
        }
        if (Input.GetKeyUp(KeyCode.F) /*&& lockedObject != null && isGrounded && !isCollected*/)
        {
            if (lockedObject != null && isGrounded)
            {
                playerAnim.SetBool("isPulling", false);
                isFpressed = false;
                lockedObject = null;
                //lockedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            }
        }
        if (/*!isCollected &&*/ lockedObject != null && (lockedObject.GetComponent<Rigidbody2D>().bodyType != RigidbodyType2D.Static))
        {
            lockedObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, lockedObject.GetComponent<Rigidbody2D>().velocity.y);
        }

        // JUMP
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && /*!isCollected &&*/ lockedObject == null)
        {
            audioSource.PlayOneShot(jumpingSound);
            body.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            // doubleJump = true;

            //jumping effect
            Instantiate(jumpEffect, effectPos, Quaternion.identity);
        }
        //else if (Input.GetButtonDown("Jump") && doubleJump)
        //{
        //    body.AddForce(new Vector2(0, DoubleJumpForce));
        //    anim.SetTrigger("Jump");
        //    doubleJump = false;
        //}

        // Code end of level (play small animation
        /*if (isCollected && (transform.position != spaceShip.position))
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
        }*/

        // Flip the player when require
        if (((speed > 0 && !facingRight) || (speed < 0 && facingRight)) && !Input.GetKey(KeyCode.F))
        {
            Flip();
        }

        if (!isGrounded)
        {
            RaycastHit2D ray;

            // Get top of platform
            Bounds bounds = GetComponent<SpriteRenderer>().bounds;

            Vector2 startRay;
            if (facingRight)
            {
                startRay = new Vector2(bounds.center.x + (bounds.size.x / 2) + 0.1f, bounds.center.y + (bounds.size.y / 2)+0.1f);
            }
            else
            {
                startRay = new Vector2(bounds.center.x - (bounds.size.x / 2) - 0.1f, bounds.center.y + (bounds.size.y / 2)+0.1f);
            }
            ray = Physics2D.Raycast(startRay, new Vector2(0, -bounds.size.y - 0.1f));

            if (ray.collider != null && ray.distance < bounds.size.y && ray.collider.tag != "CoveringLayer")
            {
                body.velocity = new Vector3(0, body.velocity.y, 0);
            }
        }
    }
    
    private void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-1 * transform.localScale.x, transform.localScale.y, 1);
    }

    IEnumerator victory()
    {
        setLevelBool();
        SceneManager.LoadScene("InformationScreen");
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();      
        yield return new WaitForSeconds(0.1f);
        audioSource.PlayOneShot(victorySound);
    }

    Vector3 vectorPlatform;

    // Collecting the materials
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "TheOre")
        {
            Destroy(other.gameObject);
            audioSource.PlayOneShot(collectingSound);
            countItems += 1;
            itemUI.GetComponent<Text>().text = countItems + "/" + maxItems;

            if (countItems == maxItems)
            {
                StartCoroutine(victory());
            }
        }
    }

    // Validation of levels
    private void setLevelBool() {
        string levelName = SceneManager.GetActiveScene().name;
        if (levelName == "Mars"){
            manager.marsFinished = true;
            manager.lastLevelFinished = "Mars";
        }
    }
}
