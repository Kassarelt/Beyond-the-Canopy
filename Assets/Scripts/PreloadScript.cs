using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreloadScript : MonoBehaviour {

    private void Awake()
    {

        if (LoadingSceneIntegration.otherScene > 0)
        {
            SceneManager.LoadScene(LoadingSceneIntegration.otherScene);
        }
        else {
            SceneManager.LoadScene("Group");
        }
    }
}
