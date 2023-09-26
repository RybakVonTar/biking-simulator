using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceCounter : MonoBehaviour {

    public TextMeshProUGUI countText;
    public float previousDiff;
    public float diff;
    public float startDistance;
    public BikeFrame bike;
    public float bikeDistance;
    public float displayCount;
    public float levelTime;
    public int coinValues;

    void Start() {
        countText.text = "Distance: 0 m";
        startDistance = bike.transform.position.x;

        LoadSave load = JsonUtility.FromJson<LoadSave>(FileManager.LoadFromFile("loadSaveData.json"));
        if (load != null && load.load) {
            LoadSave();
        }
    }

    void Update() {
        bikeDistance = bike.transform.position.x;
        diff = bikeDistance - startDistance;
        if (previousDiff < diff) {
            displayCount += diff - previousDiff;
            previousDiff = diff;
            countText.text = "Distance: " + Math.Truncate(displayCount).ToString() + " m";
        }

        levelTime += Time.deltaTime;        
    }

    public void CollectCoin(int value) {
        coinValues += value;
        countText.text = "Distance: " + Math.Truncate(displayCount).ToString() + " m";
    }

    private void LoadSave() { 
        string json_distance = FileManager.LoadFromFile("scoreSaveData.json");
        Debug.Log(json_distance);
        JsonUtility.FromJsonOverwrite(json_distance, this);
        Debug.Log(bikeDistance);
        startDistance = bike.transform.position.x;
    }
}
