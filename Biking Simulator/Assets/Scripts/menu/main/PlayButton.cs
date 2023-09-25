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
        else 
        {
            SceneManager.LoadScene(sceneName: sceneName); 
        }
    }
}
