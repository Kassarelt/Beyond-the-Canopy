using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EscapeMenu : MonoBehaviour {

    public GameObject escapeMenu;
    public bool isPaused;

    public Animator transitionAnim;
    public GameObject player;
    public Slider slider;

    // Use this for initialization
    void Start () {
        isPaused = false;
        escapeMenu.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            isPaused = !isPaused;
            escapeMenu.SetActive(isPaused);
            if (isPaused)
            {
                Time.timeScale = 0;
            }
            else {
                Time.timeScale = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            FreezeWinLoose();
            Reload();
        }
	}

    public void FreezeWinLoose() {
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        slider.value = 10f;
    }

    public void Reload()
    {
        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2.5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
