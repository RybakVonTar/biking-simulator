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

    private EscapeHandler script;
    void Start() {
        script = FindObjectOfType<EscapeHandler>();
    }

    void OnTriggerEnter2D() {
        scoreDisplay.text = "Score\n" + Math.Truncate((counter.displayCount + counter.coinValues) / counter.levelTime * 1000);
        script.menu = true;
        script.restartButton.SetActive(true);
        script.exitButton.SetActive(true);
        GetComponent<BoxCollider2D>().isTrigger = false;
    }
}
