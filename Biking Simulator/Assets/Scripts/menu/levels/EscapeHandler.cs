using System.Collections;
using System.Collections.Generic;
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
            Menu();
        }
        if (GetComponent<Camera>().isActiveAndEnabled) {}
        if (death && SceneManager.GetActiveScene().name == levelName) {
            Menu();
            continueButton.SetActive(false);
            restartButton.SetActive(true);
            exitButton.SetActive(true);
            FileManager.WriteToFile("loadSaveData.json", new LoadSave(false));
        } 
        else if (!menu)
        {
            continueButton.SetActive(false);
            restartButton.SetActive(false);
            exitButton.SetActive(false);
        }
    }

    void Menu() {
        menu = true;
        continueButton.SetActive(true);
        restartButton.SetActive(true);
        exitButton.SetActive(true);
    }
}
