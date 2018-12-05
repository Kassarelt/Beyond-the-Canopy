using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameVersion : MonoBehaviour {

	private Text gameVersionText;

	// Use this for initialization
	void Start () {
		gameVersionText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		gameVersionText.text = "Beyond the Canopy, Version a." + Application.version;
	}
}
