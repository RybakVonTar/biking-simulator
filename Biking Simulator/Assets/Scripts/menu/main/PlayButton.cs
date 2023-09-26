using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Button yourButton;
    public string sceneName;
    public bool exit;
    public bool save;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        
    }

    void TaskOnClick()
    {
        if (exit)
        {
            Application.Quit();
        }
        else if (save)
        {
            BikeFrame bike = FindObjectOfType<BikeFrame>();
            bike.position = bike.transform.position;
            FileManager.WriteToFile("bikeSaveData.json", bike);
            FileManager.WriteToFile("levelSaveData.json", new LevelSave(SceneManager.GetActiveScene().name));
            FileManager.WriteToFile("loadSaveData.json", new LoadSave(true));

            SceneManager.LoadScene(sceneName: sceneName);
            
        } 
        else
        {
            SceneManager.LoadScene(sceneName: sceneName); 
        }
    }
}
