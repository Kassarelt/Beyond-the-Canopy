using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTimer : MonoBehaviour {

    // Variable to parameter to choose time
    public float timeOfLevel = 30;
    public Slider timeBar;
    [Range(0, 2f)]
    public float timeSpeed;
    [Range(0,30f)]
    public float spikeDamage;
    [Range(0, 30f)]
    public float lavaDamage;
    [Range(0, 30f)]
    public float trapDamage;

    // Fields that script must fill
    public SceneTransitionMenu sceneManager;

    // Check if player is Grounded (to fall)
    private Player playerMoveScript;
    private bool wasGrounded = true;
    public float fallDamage;
    public float velocityFallMax;

    // Variable for sound effect
    private AudioSource audioSource;
    public AudioClip spikeHitSound;
    public AudioClip loseSound;

    // Variable to check ground
    public bool isGrounded = false;
    public float groundCheckRadius = 0.1f;
    public LayerMask WhatIsGround;
    private Transform groundCheck;

    //storing the colors to change the alpha in coroutine
    private Color hitColor1 = new Color(0, 0.9411765f, 1);
    private Color hitColor2 = new Color(1f, 1f, 1f);

    // Use this for initialization
    void Start () {

        // timeBar init
        timeBar.gameObject.SetActive(true);

        // Create audioSource if not exist
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Get some Components for player
        playerMoveScript = gameObject.GetComponent<Player>();
        groundCheck = GameObject.Find("groundCheck").transform;
    }
	
	// Update is called once per frame
	void LateUpdate () {
        FallDmg();
        TimeCounter();
    }

    void FallDmg()
    {
        // Use velocity (which Improve) to know if player must take damage and how much he get
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, WhatIsGround);
        if (!wasGrounded && isGrounded && gameObject.GetComponent<Rigidbody2D>().velocity.y < -velocityFallMax)
        {
            timeBar.value -= fallDamage * (-gameObject.GetComponent<Rigidbody2D>().velocity.y - velocityFallMax);
            StartCoroutine(hitAnimation());
        }
        wasGrounded = isGrounded;
    }

    void TimeCounter()
    {
        if (timeBar.value >= 0)
        {
            timeBar.value -= (timeSpeed / 10) * Time.deltaTime;

            // Death Condition
            if (timeBar.value == 0)
            {
                StartCoroutine(death());
                timeBar.value = 100f;
            }
        }
       
    }

    // Dmg of Environment
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            timeBar.value -= spikeDamage;
            StartCoroutine(hitAnimation());
        }
        if (collision.gameObject.tag == "Lava")
        {
            timeBar.value -= lavaDamage;
            StartCoroutine(hitAnimation());
        }
    }

    private void OnParticleCollision(GameObject steamTraps)
    {
        Debug.Log("Dmg");
        timeBar.value -= trapDamage;
        StartCoroutine(hitAnimation());
    }

    IEnumerator death()
    {
        timeBar.gameObject.SetActive(false);
        sceneManager.Reload();
        GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(0.1f);
        audioSource.PlayOneShot(loseSound); 
    }

    //using coroutine to change the players sprite color in order to keep the animation cycle easy
    IEnumerator hitAnimation()
    {
        audioSource.PlayOneShot(spikeHitSound);
        gameObject.GetComponent<SpriteRenderer>().color = hitColor1;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = hitColor2;
        yield return new WaitForSeconds(0.1f);
        audioSource.PlayOneShot(spikeHitSound);
        gameObject.GetComponent<SpriteRenderer>().color = hitColor1;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = hitColor2;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = hitColor1;
        yield return new WaitForSeconds(0.1f);
        gameObject.GetComponent<SpriteRenderer>().color = hitColor2;
    }
}
