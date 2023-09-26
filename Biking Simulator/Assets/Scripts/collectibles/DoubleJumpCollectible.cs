using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpCollectible : MonoBehaviour {
    public BikeFrame bike;
    public bool collected = false;
    
    void OnTriggerEnter2D() {
        Debug.Log("DOUBLE JUMP collected");
        bike.doubleJump = true;
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
