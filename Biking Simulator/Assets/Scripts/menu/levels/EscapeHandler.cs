using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeHandler : MonoBehaviour {
    public GameObject continueButton;
    public GameObject restartButton;
    public GameObject exitButton;
    public bool menu;
    public bool death;
    public string levelName;

    void Start() {
        menu = false;
        continueButton.SetActive(false);
        restartButton.SetActive(false);
        exitButton.SetActive(false);
        levelName = SceneManager.GetActiveScene().name;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            menu = true;
            continueButton.SetActive(true);
            restartButton.SetActive(true);
            exitButton.SetActive(true);
        }
        if (GetComponent<Camera>().isActiveAndEnabled) {}
        if (death && SceneManager.GetActiveScene().name == levelName) {
            continueButton.SetActive(false);
            restartButton.SetActive(true);
            exitButton.SetActive(true);
        } 
        else if (!menu)
        {
            continueButton.SetActive(false);
            restartButton.SetActive(false);
            exitButton.SetActive(false);
        }
    }
}
