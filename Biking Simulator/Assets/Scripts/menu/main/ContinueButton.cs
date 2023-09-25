using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ContinueButton : MonoBehaviour {
    void Start() {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick() {
        string json_level = FileManager.LoadFromFile("levelSaveData.json");
        LevelSave levelName = JsonUtility.FromJson<LevelSave>(json_level);

        SceneManager.LoadScene(sceneName: levelName.levelName); 
    }
}
