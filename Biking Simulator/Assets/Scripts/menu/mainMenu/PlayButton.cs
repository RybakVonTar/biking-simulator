using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Button yourButton;
    public string sceneName;

    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene(sceneName: sceneName);
    }
}
