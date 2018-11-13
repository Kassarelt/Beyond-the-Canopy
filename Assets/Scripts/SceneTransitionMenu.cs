using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionMenu : MonoBehaviour {

	public Animator transitionAnim;
	public string sceneName1;
	public string sceneName2;
	public string sceneName3;
	public string sceneName4;

	public void NewGame(){
		StartCoroutine (LoadScene1());
	}

	IEnumerator LoadScene1(){
		transitionAnim.SetTrigger ("end");
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene (sceneName1);
	}

	public void LoadGame(){
		StartCoroutine (LoadScene2());
	}

	IEnumerator LoadScene2(){
		transitionAnim.SetTrigger ("end");
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene (sceneName2);
	}

	public void Options(){
		StartCoroutine (LoadScene3());
	}

	IEnumerator LoadScene3(){
		transitionAnim.SetTrigger ("end");
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene (sceneName3);
	}

	public void Quit(){
		StartCoroutine (LoadScene4());
	}

	IEnumerator LoadScene4(){
		transitionAnim.SetTrigger ("end");
		yield return new WaitForSeconds (2.5f);
		SceneManager.LoadScene (sceneName4);
	}
}