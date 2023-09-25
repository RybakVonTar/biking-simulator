using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeHandler : MonoBehaviour {
    public BikeFrame bike;

    void Update() {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // save position in level atc.
            bike.position = bike.transform.position;
            FileManager.WriteToFile("bikeSaveData.json", bike);
            FileManager.WriteToFile("levelSaveData.json", new LevelSave(SceneManager.GetActiveScene().name));
            FileManager.WriteToFile("loadSaveData.json", new LoadSave(true));
            SceneManager.LoadScene(sceneName: "Menu");
        }
    }
}
