using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{

    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;

    private GameObject player;

    public float smoothTime = 0.125f;
    private Vector3 velocity = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // LateUpdate is called right after Update
    void LateUpdate()
    {
        float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
        float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
        Vector3 desiredPosition = new Vector3(x, y, gameObject.transform.position.z);
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity , smoothTime);
        gameObject.transform.position = smoothedPosition;
    }
}
