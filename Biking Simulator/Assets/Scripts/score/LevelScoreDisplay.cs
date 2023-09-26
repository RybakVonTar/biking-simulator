using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelScoreDisplay : MonoBehaviour {

    public TextMeshProUGUI scoreDisplay;
    public DistanceCounter counter;
    public GameObject restartButton;
    public GameObject exitButton;

    void OnTriggerEnter2D() {
        scoreDisplay.text = "Score\n" + Math.Truncate((counter.displayCount + counter.coinValues) / counter.levelTime * 1000);
        restartButton.SetActive(true);
        exitButton.SetActive(true);
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
