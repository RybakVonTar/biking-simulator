using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        buttonList[unlockedLevel].GetComponent<Buttons>().locked = false;
    }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
