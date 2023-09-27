using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUnlock : MonoBehaviour
{
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;
    public GameObject buttonEndless;

    public int unlockedLevel;
    private List<GameObject> buttonList;
    void Start()
    {
        unlockedLevel = 0;
        buttonList = new List<GameObject>();
        buttonList.Add(button1);
        buttonList.Add(button2);
        buttonList.Add(button3);
        buttonList.Add(button4);
        buttonList.Add(button5);
        buttonList.Add(button6);
        buttonList.Add(button7);
        buttonList.Add(button8);
        buttonList.Add(buttonEndless);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Levels") {
            buttonList.Clear();
            buttonList.Add(GameObject.Find("Level 1"));
            buttonList.Add(GameObject.Find("Level 2"));
            buttonList.Add(GameObject.Find("Level 3"));
            buttonList.Add(GameObject.Find("Level 4"));
            buttonList.Add(GameObject.Find("Level 5"));
            buttonList.Add(GameObject.Find("Level 6"));
            buttonList.Add(GameObject.Find("Level 7"));
            buttonList.Add(GameObject.Find("Level 8"));
            buttonList.Add(GameObject.Find("Endless"));
            buttonList[unlockedLevel].GetComponent<Buttons>().locked = false;
        }
        
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
