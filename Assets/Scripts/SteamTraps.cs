using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamTraps : MonoBehaviour {

    public List<ParticleCollisionEvent> collisionEvents;

    private void Start()
    {
        collisionEvents = new List<ParticleCollisionEvent>();
    }
    private void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = GetComponent<ParticleSystem>().GetCollisionEvents(other, collisionEvents);

        Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;

        while (i < numCollisionEvents)
        {
            if (rb)
            {
                Debug.Log(numCollisionEvents);
            }
            i++;
        }
    }
}
