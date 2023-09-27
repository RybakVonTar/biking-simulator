using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ContinueButton : MonoBehaviour {
    public Button btn;
    
    void Start() {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void Update() {
        string json_load = FileManager.LoadFromFile("loadSaveData.json");
        LoadSave load = JsonUtility.FromJson<LoadSave>(json_load);
        if (load != null && load.load) {
            btn.interactable = true;
        }
        else {
            btn.interactable = false;
        }
    }

    void TaskOnClick() {
        string json_level = FileManager.LoadFromFile("levelSaveData.json");
        LevelSave levelName = JsonUtility.FromJson<LevelSave>(json_level);
        string json_load = FileManager.LoadFromFile("loadSaveData.json");
        LoadSave load = JsonUtility.FromJson<LoadSave>(json_load);
        Debug.Log(load.load);
        if (load != null && load.load) {
            SceneManager.LoadScene(sceneName: levelName.levelName);     
        }
    }
}
