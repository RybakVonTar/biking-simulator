using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour {
    public DistanceCounter counter;
    public int coinValue;
    public bool collected = false;
    
    void OnTriggerEnter2D() {
        Debug.Log("COIN collected");
        counter.CollectCoin(coinValue);
        collected = true;
        Delete();
    }

    void Update() {
        if (collected) {
            Delete();
        }
    }

    private void Delete() {
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<CircleCollider2D>());
    }
}
