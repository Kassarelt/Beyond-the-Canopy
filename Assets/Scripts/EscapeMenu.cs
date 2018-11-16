using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapeMenu : MonoBehaviour {

    public GameObject escapeMenu;
    public bool isPaused;

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
        }
	}
}
