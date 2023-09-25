using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DistanceCounter : MonoBehaviour {

    public TextMeshProUGUI countText;
    private float previousDiff;
    private float diff;
    private float startDistance;
    public BikeFrame bike;
    private float bikeDistance;
    public float displayCount;
    public float levelTime;
    public int coinValues;

    void Start() {
        countText.text = "Distance: 0 m";
        startDistance = bike.transform.position.x;
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
}
