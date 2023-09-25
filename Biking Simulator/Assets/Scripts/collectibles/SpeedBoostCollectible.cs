using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostCollectible : MonoBehaviour {
    public BikeFrame bike;
    
    void OnTriggerEnter2D() {
        Debug.Log("SPEED BOOST collected");
        bike.speedBoost = true;

        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(this);
    }
}
