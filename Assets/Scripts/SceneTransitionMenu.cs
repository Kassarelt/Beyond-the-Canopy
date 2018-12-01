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
		transitionAnim.SetTrigger ("end");
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene (newGame);
	}

	public void LoadGame(){
		StartCoroutine (LoadScene2());
	}

	IEnumerator LoadScene2(){
		transitionAnim.SetTrigger ("end");
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene (loadGame);
	}

	public void Options(){
		StartCoroutine (LoadScene3());
	}

	IEnumerator LoadScene3(){
		transitionAnim.SetTrigger ("end");
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene (options);
	}

	public void Menu(){
		StartCoroutine (LoadScene4());
	}

	IEnumerator LoadScene4(){
		transitionAnim.SetTrigger ("end");
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene (menu);
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