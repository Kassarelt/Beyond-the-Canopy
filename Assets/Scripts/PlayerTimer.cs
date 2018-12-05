using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTimer : MonoBehaviour {

    public float timeOfLevel = 10f;
    public Slider timeBar;
    [Range(0, 2f)]
    public float timeSpeed;
    [Range(0,100f)]
    public float spikeDamage;
    [Range(0, 100f)]
    public float lavaDamage;
    [Range(0, 100f)]
    public float trapDamage;

    public Text timerValueIndicator;

    public SceneTransitionMenu sceneManager;

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
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        playerMoveScript = gameObject.GetComponent<Player>();
        groundCheck = GameObject.Find("groundCheck").transform;
        timerValueIndicator.text = timeBar.value.ToString();
    }
	
	// Update is called once per frame
	void LateUpdate () {
        FallDmg();
        TimeCounter();
    }

    void FallDmg()
    {
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
            timerValueIndicator.text = timeBar.value.ToString();

            if (timeBar.value == 0)
            {
                StartCoroutine(death());
                timeBar.value = 100f;
            }
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spike")
        {
            timeBar.value -= spikeDamage;
            StartCoroutine(hitAnimation());
            timerValueIndicator.text = timeBar.value.ToString();
        }
        if (collision.gameObject.tag == "Lava")
        {
            timeBar.value -= lavaDamage;
            StartCoroutine(hitAnimation());
            timerValueIndicator.text = timeBar.value.ToString();
        }
    }

    private void OnParticleCollision(GameObject steamTraps)
    {
        
            Debug.Log("Dmg");
            timeBar.value -= trapDamage;
            StartCoroutine(hitAnimation());
            timerValueIndicator.text = timeBar.value.ToString();
        
    }

    IEnumerator death()
    {
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
