using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeHandler : MonoBehaviour {
    public GameObject continueButton;
    public GameObject restartButton;
    public GameObject exitButton;

    public bool menu;

    void Start() {
        menu = false;
        continueButton.SetActive(false);
        restartButton.SetActive(false);
        exitButton.SetActive(false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            menu = true;
            continueButton.SetActive(true);
            restartButton.SetActive(true);
            exitButton.SetActive(true);
        }
        if (!menu)
        {
            continueButton.SetActive(false);
            restartButton.SetActive(false);
            exitButton.SetActive(false);
        }
    }
}
