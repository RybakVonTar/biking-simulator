using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject tile0;
    public GameObject tile1;
    public GameObject tile2;
    public GameObject tile3;
    public GameObject tile4;
    public GameObject tile5;
    public GameObject tile6;
    public GameObject tile7;
    public GameObject tile8;
    public GameObject tile9;
    public GameObject camera;

    public float lenght;
    private int index;

    private List<GameObject> tile_list;

    void Start()
    {
        tile_list = new List<GameObject>();
        tile_list.Add(tile0);
        tile_list.Add(tile1);
        tile_list.Add(tile2);
        tile_list.Add(tile3);
        tile_list.Add(tile4);
        tile_list.Add(tile5);
        tile_list.Add(tile6);
        tile_list.Add(tile7);
        tile_list.Add(tile8);
        tile_list.Add(tile9);
        
        index = 0;

        /*LoadSave load = JsonUtility.FromJson<LoadSave>(FileManager.LoadFromFile("loadSaveData.json"));
        if (load != null && load.load) {
            LoadSave();
        }*/
    }

    void Update() 
    {
        // tiles
        if (Mathf.Round(camera.transform.position.x) == tile_list[index].transform.position.x && index < 9)
        {
            //lenght = tile_list[index].bound.size.x/2 + tile_list[index-1]sprite.bound.size.x/2;
            index ++;
            tile_list[index].transform.position = new Vector2(tile_list[index-1].transform.position.x + lenght, -1.5f);
            Debug.Log("new tile generated");
        }
    }

    /*private void LoadSave() {
        string json_bike = FileManager.LoadFromFile("generationSaveData.json");
        JsonUtility.FromJsonOverwrite(json_bike, this);
        Debug.Log(transform.position);
        GameObject[] wheelsList = FindObjectsOfType<GameObject>();

        transform.position = position;
    }*/
} 
