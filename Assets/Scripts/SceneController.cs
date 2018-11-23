using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Player player;
    public Slider timeBar;
    [Range(0f,2f)]
    public float timeSpeed;
    
    private int currentBuildIndex;
    private float maxTime = 10f;
    private float currentTime;

    private void Start()
    {
        currentBuildIndex = SceneManager.GetActiveScene().buildIndex;
        timeBar.value = 0;
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
    private void Update()
    {
        TimeCounter();
    }
    public void TimeCounter()
    {
        if (!player.isCollected)
        {
            if (timeBar.value <= 1f)
            {
                timeBar.value += (timeSpeed / 10) * Time.deltaTime;
                if (timeBar.value == 1)
                {
                    //GameOver
                    SceneManager.LoadScene(1);
                }
            }
        }
        else
        {
            timeSpeed = 0;
        }
    }
}
