using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpCollectible : MonoBehaviour {
    public BikeFrame bike;
    
    void OnTriggerEnter2D() {
        Debug.Log("DOUBLE JUMP collected");
        bike.doubleJump = true;

        Destroy(GetComponent<SpriteRenderer>());
        Destroy(GetComponent<CircleCollider2D>());
        Destroy(this);
    }
}
