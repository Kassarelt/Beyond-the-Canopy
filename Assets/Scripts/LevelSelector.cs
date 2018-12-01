using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    public Image bigPlanetFrame;
    public Text bigPlanetName;
    public Text bigPlanetInfo;
    public Text profText;

    public Button startButton;

    public SceneTransitionMenu sceneManager;

    public Sprite[] bigPlanets;

    public void Start()
    {
        Mars();
    }

    public void Mercury()
    {
        startButton.interactable = false;
        //sceneManager.newGame = "Mercury";

        bigPlanetFrame.sprite = bigPlanets[0];
        bigPlanetName.text = "Mercury";

        profText.text = "I'm sorry, Mercury level is not yet implemented.";
    }

    public void Venus()
    {
        startButton.interactable = false;
        //sceneManager.newGame = "Venus";

        bigPlanetFrame.sprite = bigPlanets[1];
        bigPlanetName.text = "Venus";

        profText.text = "I'm sorry, Venus level is not yet implemented.";
    }

    public void Earth()
    {
        startButton.interactable = false;
        //sceneManager.newGame = "Earth";

        bigPlanetFrame.sprite = bigPlanets[2];
        bigPlanetName.text = "Earth";

        profText.text = "I'm sorry, Earth level is not yet implemented.";
    }

    public void Mars()
    {
        startButton.interactable = true;
        sceneManager.newGame = "RalphsPlatformScene";

        bigPlanetFrame.sprite = bigPlanets[3];
        bigPlanetName.text = "Mars";
        bigPlanetInfo.text = "- Volume:\n   163.18*10^9 km3\n   (0.107 Earth)\n- Daytime:\n   24.6 h\n- Yeartime:\n   686.98d";
        profText.text = "This is just to test how it looks when the text is very very very very very very very very very very very very very very very very very very very very very long.";
    }

    public void Jupiter()
    {
        startButton.interactable = false;
        //sceneManager.newGame = "Jupiter";

        bigPlanetFrame.sprite = bigPlanets[4];
        bigPlanetName.text = "Jupiter";

        profText.text = "I'm sorry, Jupiter level is not yet implemented.";
    }

    public void Saturn()
    {
        startButton.interactable = false;
        //sceneManager.newGame = "Saturn";

        bigPlanetFrame.sprite = bigPlanets[5];
        bigPlanetName.text = "Saturn";

        profText.text = "I'm sorry, Saturn level is not yet implemented.";
    }

    public void Uranus()
    {
        startButton.interactable = false;
        //sceneManager.newGame = "Uranus";

        bigPlanetFrame.sprite = bigPlanets[6];
        bigPlanetName.text = "Uranus";

        profText.text = "I'm sorry, Uranus level is not yet implemented.";
    }

    public void Neptune()
    {
        startButton.interactable = false;
        //sceneManager.newGame = "Neptune";

        bigPlanetFrame.sprite = bigPlanets[7];
        bigPlanetName.text = "Neptune";

        profText.text = "I'm sorry, Neptune level is not yet implemented.";
    }
}
