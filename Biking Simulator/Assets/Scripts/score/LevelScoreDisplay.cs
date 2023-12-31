using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelScoreDisplay : MonoBehaviour {

    public TextMeshProUGUI scoreDisplay;
    public DistanceCounter counter;
    public BikeWheels frontWheel;
    public BikeWheels backWheel;

    public int currentLevel;

    private EscapeHandler script;
    private LevelUnlock levelUnlock;
    void Start() {
        script = FindObjectOfType<EscapeHandler>();
        levelUnlock = FindObjectOfType<LevelUnlock>();
    }

    void OnTriggerEnter2D() {
        scoreDisplay.text = "Score\n" + Math.Truncate((counter.displayCount + counter.coinValues) / counter.levelTime * 1000);
        script.menu = true;
        script.restartButton.SetActive(true);
        script.exitButton.SetActive(true);
        GetComponent<BoxCollider2D>().isTrigger = false;

        frontWheel.GetComponent<HingeJoint2D>().useMotor = false;
        backWheel.GetComponent<HingeJoint2D>().useMotor = false;
        FileManager.WriteToFile("loadSaveData.json", new LoadSave(false));

        if (levelUnlock.unlockedLevel < currentLevel) {
            levelUnlock.unlockedLevel ++;
        }
    }
}
