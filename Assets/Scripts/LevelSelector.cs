using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour {

    // Field to fill
    public Image bigPlanetFrame;
    public Text bigPlanetName;
    public Text bigPlanetInfo;
    public Text profText;
    public Text profName;
    public Text profInformation;

    // Button to start kevek
    public Button startButton;

    public SceneTransitionMenu sceneManager;

    public Sprite[] bigPlanets;

    // GameManager access
    private GameManager manager;

    public void Start()
    {
        // Put Informations about Professor
        manager = GameObject.FindObjectOfType<GameManager>();
        profName.text = "Professor Spacestein";
        profInformation.text = "Age: 64\nSize: 1m65\nWeight: Too Much\nHobbies: eat burritos in front of Star Wars";

        // Start by Default on Mars (only this level is available)
        if (manager.firstOpenInfoScreen)
        {
            manager.firstOpenInfoScreen = false;
            Mars();
        }
        else if (manager.marsFinished && manager.lastLevelFinished == "Mars") {
            Mars();
            profText.text = "Good job Challenger 42! I'm happy you managed to gather all Chronoton crystals on Mars without troubles.\n\nI must admit I was not expecting you to return that quickly and I don't have any further missions for you...\n\nAnyway, thanks for the crystals! I will contact you as soon as I have a new missions.\nOver";
        }
    }

    public void Mercury()
    {
        startButton.interactable = false;
        //sceneManager.newGame = "Mercury";

        bigPlanetFrame.sprite = bigPlanets[0];
        bigPlanetName.text = "Mercury";
        bigPlanetInfo.text = "Volume:\n  60.83*E9 km3\n  (0.056 Earth)\n\nDaytime:\n  58.6d\n\nOrbital period:\n  87.97d";
        profText.text = "I'm sorry, Mercury level is not yet implemented.";
    }

    public void Venus()
    {
        startButton.interactable = false;
        //sceneManager.newGame = "Venus";

        bigPlanetFrame.sprite = bigPlanets[1];
        bigPlanetName.text = "Venus";
        bigPlanetInfo.text = "Volume:\n  928.43*E9 km3\n  (0.815 Earth)\n\nDaytime:\n  243d\n\nOrbital period:\n  224.7d";
        profText.text = "I'm sorry, Venus level is not yet implemented.";
    }

    public void Earth()
    {
        startButton.interactable = false;
        //sceneManager.newGame = "Earth";

        bigPlanetFrame.sprite = bigPlanets[2];
        bigPlanetName.text = "Earth";
        bigPlanetInfo.text = "Volume:\n  1083.21*E9 km3\n  (1 Earth)\n\nDaytime:\n  23.93h\n\nOrbital period:\n  365.26d";
        profText.text = "I understand you are a bit afraid of this adventure but there is nothing for you to do on Earth.";
    }

    public void Mars()
    {
        sceneManager.newGame = "Mars";

        bigPlanetFrame.sprite = bigPlanets[3];
        bigPlanetName.text = "Mars";
        bigPlanetInfo.text = "Volume:\n  163.18*E9 km3\n  (0.107 Earth)\n\nDaytime:\n  24.6h\n\nOrbital period:\n  686.98d";
        if (!manager.marsFinished)
        {
            startButton.interactable = true;
            profText.text = "Welcome Challenger 42,\n\nIt's on Mars that you will do your first test. Remember, you must proove that you deserve more than others to be the first human to travel beyond the Solar System.\n\nYour missions is to collect Chronoton crystals/Dilithium all around the planet.\n\nThe air of Mars isn't breathable, so your time is limited.\n\nIn addition, the core of the planet is hot and your suit won't stand a long exposure.\n\nThe gravity is three time lower than on earth. Make good use of this but remember, a rough landing could damaged your suit or even worse if you are not careful enough.\n\nGood Luck Challenger 42.";
        }
        else {
            startButton.interactable = false;
            profText.text = "You've done well Challenger 42 on planet Mars!\nNo need to go back there, you already collected all Chronoton crystals.";
        }
    }

    public void Jupiter()
    {
        startButton.interactable = false;
        //sceneManager.newGame = "Jupiter";

        bigPlanetFrame.sprite = bigPlanets[4];
        bigPlanetName.text = "Jupiter";
        bigPlanetInfo.text = "Volume:\n  1431.28*E12 km3\n  (1321.3 Earth)\n\nDaytime:\n  9.92h\n\nOrbital period:\n  4335.35d";
        profText.text = "I'm sorry, Jupiter level is not yet implemented.";
    }

    public void Saturn()
    {
        startButton.interactable = false;
        //sceneManager.newGame = "Saturn";

        bigPlanetFrame.sprite = bigPlanets[5];
        bigPlanetName.text = "Saturn";
        bigPlanetInfo.text = "Volume:\n  827.13*E12 km3\n  (763 Earth)\n\nDaytime:\n  10.55h\n\nOrbital period:\n  29.45y";
        profText.text = "I'm sorry, Saturn level is not yet implemented.";
    }

    public void Uranus()
    {
        startButton.interactable = false;
        //sceneManager.newGame = "Uranus";

        bigPlanetFrame.sprite = bigPlanets[6];
        bigPlanetName.text = "Uranus";
        bigPlanetInfo.text = "Volume:\n  6833.44*E10 km3\n  (63.085 Earth)\n\nDaytime:\n  17.24h\n\nOrbital period:\n  84y";
        profText.text = "I'm sorry, Uranus level is not yet implemented.";
    }

    public void Neptune()
    {
        startButton.interactable = false;
        //sceneManager.newGame = "Neptune";

        bigPlanetFrame.sprite = bigPlanets[7];
        bigPlanetName.text = "Neptune";
        bigPlanetInfo.text = "Volume:\n  625.26*E11 km3\n  (57.74 Earth)\n\nDaytime:\n  16.1h\n\nOrbital period:\n  164.88y";
        profText.text = "I'm sorry, Neptune level is not yet implemented.";
    }
}
