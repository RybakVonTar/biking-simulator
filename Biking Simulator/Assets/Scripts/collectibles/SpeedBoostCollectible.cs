using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoostCollectible : MonoBehaviour {
    public BikeFrame bike;
    public bool collected = false;

    void OnTriggerEnter2D() {
        Debug.Log("SPEED BOOST collected");
        bike.speedBoost = true;
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
