using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level_generation : MonoBehaviour
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

    public int speed;

    private int tile0_index;
    private int tile1_index;

    private List<GameObject> tile_list;

    void Start()
    {
        tile_list = new List<GameObject>();
        tile0_index = 0;
        tile1_index = 0;
    }

    void Update() 
    {
        if (camera.transform.position.x > tile0.transform.position.x + 2)
        {
            tile0_index ++;
            tile1_index ++;
        }
        if (camera.transform.position.x < tile0.transform.position.x - 2)
        {
            tile0_index --;
            tile1_index --;
        }
    }
} 
