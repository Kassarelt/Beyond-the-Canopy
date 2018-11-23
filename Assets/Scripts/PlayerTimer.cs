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

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimeCounter();


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
