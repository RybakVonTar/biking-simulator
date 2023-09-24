using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoCollectible : MonoBehaviour {

    private CircleCollider2D col;

    void Start() {
        col = GetComponent<CircleCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D col) {
        Debug.Log("Demostration collectible collected");
        Destroy(GetComponent<SpriteRenderer>());
        Destroy(this);
    }
}
