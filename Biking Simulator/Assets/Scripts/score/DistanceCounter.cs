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
        JsonUtility.FromJsonOverwrite(json_distance, this);
        bike = FindObjectOfType<BikeFrame>();
        TextMeshProUGUI[] countTextList = FindObjectsOfType<TextMeshProUGUI>();
        for (int i = 0; i < countTextList.Length; i += 1) {
            if (countTextList[i].CompareTag("distanceDisplay")) {
                countText = countTextList[i];
            }
        }
    }
}
