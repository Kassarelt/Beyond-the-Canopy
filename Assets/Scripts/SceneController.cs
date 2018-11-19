using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public int indexScene;

    private int currentBuildIndex;

    private void Start()
    {
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    public void SceneShifter(int index)
    {
        SceneManager.LoadScene(index);
    }
    public void NextScene()
    {
        SceneManager.LoadScene(currentBuildIndex + 1);
    }
    public void PreviousScene()
    {
        SceneManager.LoadScene(currentBuildIndex - 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
