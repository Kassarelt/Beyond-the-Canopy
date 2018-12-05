using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour {

    public void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
