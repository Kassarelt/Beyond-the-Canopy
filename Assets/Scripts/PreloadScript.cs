using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadScript : MonoBehaviour {

    private void Awake()
    {

        if (LoadingSceneIntegration.otherScene > 0)
        {
            Debug.Log("Returning again to the scene: " + LoadingSceneIntegration.otherScene);
            SceneManager.LoadScene(LoadingSceneIntegration.otherScene);
        }
        else {
            SceneManager.LoadScene("Menu");
        }
    }
}
