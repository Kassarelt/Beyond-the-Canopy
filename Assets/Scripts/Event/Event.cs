using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Event : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (launchEvent()) {

        }
	}

    protected abstract bool launchEvent();
    protected abstract void playEvent();
}
