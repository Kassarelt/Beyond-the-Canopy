using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    //variable to know if the player completed the levels
    public bool mercuryFinished = false;
    public bool venusFinished = false;
    public bool earthFinished = false;
    public bool marsFinished = false;
    public bool jupiterFinished = false;
    public bool saturnFinished = false;
    public bool uranusFinished = false;
    public bool neptuneFinished = false;

    public string lastLevelFinished = "";
    public bool firstOpenInfoScreen = true;

}
