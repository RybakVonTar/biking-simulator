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
    public GameObject tile10;

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

    void update() 
    {
        if (Input.GetKeyDown(KeyCode.D) && tile0.transform.position.x <= -30 ) //&
        {
            tile1_index ++;
            Debug.Log("d");
        }
        else if (Input.GetKeyDown(KeyCode.D) && tile0.transform.position.x <= -2 )
        {
            tile0_index --;
            Debug.Log("c");
        }

        if (Input.GetKeyDown(KeyCode.A) && tile1.transform.position.x >= 30 )
        {
            tile0_index --;
            Debug.Log("b");
        }
        else if (Input.GetKeyDown(KeyCode.A) && tile1.transform.position.x >= 2 )
        {
            tile0_index ++;
            Debug.Log("a");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            tile0.transform.position = new Vector2(tile0.transform.position.x + 1 * Time.deltaTime * speed, tile0.transform.position.y);
            Debug.Log("y");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            tile0.transform.position = new Vector2(tile0.transform.position.x - 1 * Time.deltaTime * speed, tile0.transform.position.y);
            Debug.Log("x");
        }
    }
} 
