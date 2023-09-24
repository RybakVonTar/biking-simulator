using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour {

    public TextMeshProUGUI countText;
    private float previousDiff;
    private float diff;
    private float startDistance;
    public BikeFrame bike;
    private float bikeDistance;
    private float displayCount;

    void Start() {
        countText.text = "0";
        startDistance = bike.transform.position.x;
    }

    void Update() {
        bikeDistance = bike.transform.position.x;
        diff = bikeDistance - startDistance;
        if (previousDiff < diff) {
            displayCount += diff - previousDiff;
            previousDiff = diff;
            countText.text = Math.Truncate(displayCount).ToString();
        }
    }

    public void CollectCoin(int value) {
        displayCount += value;
        countText.text = Math.Truncate(displayCount).ToString();
    }
}
