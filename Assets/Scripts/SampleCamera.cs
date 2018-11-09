using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleCamera : MonoBehaviour {


    public GameObject samplePlayer;       //Public variable to store a reference to the player game object


    private Vector3 offset;         //Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //transform.position = samplePlayer.transform.position -10;

        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        //offset = transform.position - samplePlayer.transform.position;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        Vector3 posPlayer = samplePlayer.transform.position;
        posPlayer.z = -1;

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = posPlayer;
    }
}
