using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float zoomSpeed = .1f;
    public Transform targetPlanet;

    private float cameraSize;
    private bool isStarted = false;

    void Start () {
        cameraSize = GetComponent<Camera>().orthographicSize;
	}
	
    private void LateUpdate()
    {
        if (isStarted)
        {
            ZoomIntoPlanet();
        }
    }
    private void ZoomIntoPlanet()
    {
        transform.LookAt(targetPlanet);
        if (cameraSize > 0.15f)
        {
            cameraSize -= zoomSpeed * Time.deltaTime;
        }
        GetComponent<Camera>().orthographicSize = cameraSize;
    }
    public void GameStarted()
    {
        isStarted = true;
    }
}
