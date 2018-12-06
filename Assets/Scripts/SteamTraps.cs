using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamTraps : MonoBehaviour {
    
    private PlayerTimer pt;

    private void Start()
    {
        pt= FindObjectOfType<PlayerTimer>();
    }
    //private void OnParticleCollision(GameObject other)
    //{
    //    pt.timeBar.value -= 0.000005f;
        
    //}
}
