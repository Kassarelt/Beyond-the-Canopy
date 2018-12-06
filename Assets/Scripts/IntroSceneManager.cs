using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneManager : MonoBehaviour
{

    public Animator transitionAnim;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        Time.timeScale = 1;
        yield return new WaitForSeconds(3.45f);
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(2.3f);
        SceneManager.LoadScene("Menu");
    }
}
