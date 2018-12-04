using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionMenu : MonoBehaviour {

	public Animator transitionAnim;
	public string newGame;
	public string loadGame;
	public string options;
	public string menu;

	public void NewGame(){
		StartCoroutine (LoadScene1());
	}

	IEnumerator LoadScene1(){
        Time.timeScale = 1;
		transitionAnim.SetTrigger ("end");
		yield return new WaitForSeconds (2.3f);
		SceneManager.LoadScene (newGame);
	}

	public void LoadGame(){
		StartCoroutine (LoadScene2());
	}

	IEnumerator LoadScene2(){
        Time.timeScale = 1;
        transitionAnim.SetTrigger ("end");
		yield return new WaitForSeconds (2.3f);
		SceneManager.LoadScene (loadGame);
	}

	public void Options(){
		StartCoroutine (LoadScene3());
	}

	IEnumerator LoadScene3(){
        Time.timeScale = 1;
        transitionAnim.SetTrigger ("end");
		yield return new WaitForSeconds (2.3f);
		SceneManager.LoadScene (options);
	}

	public void Menu(){
		StartCoroutine (LoadScene4());
	}

	IEnumerator LoadScene4(){
        Time.timeScale = 1;
        transitionAnim.SetTrigger ("end");
		yield return new WaitForSeconds (2.3f);
		SceneManager.LoadScene (menu);
	}

    public void Reload()
    {
        StartCoroutine(ReloadScene());
    }

    IEnumerator ReloadScene()
    {
        Time.timeScale = 1;
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        StartCoroutine(QuitGame());
    }

    IEnumerator QuitGame()
    {
        Time.timeScale = 1;
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2.3f);
        Application.Quit();
    }
}