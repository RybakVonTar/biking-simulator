using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectible : MonoBehaviour {
    public DistanceCounter counter;
    public int coinValue;
    
    void OnTriggerEnter2D() {
        Debug.Log("COIN collected");
        counter.CollectCoin(coinValue);

        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(this);
    }
}
