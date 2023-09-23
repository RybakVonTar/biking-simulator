using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class BikeFrame : MonoBehaviour {

    public int speed;
    public int jumpForce;
    public float tiltForce;
    private Rigidbody2D rb;
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck()) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.A)) {
            // tilting
        } else if (Input.GetKeyDown(KeyCode.D)) {
            // tilting
        }
    }

    private bool GroundCheck() {
        if(Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, maxDistance, layerMask)) {
            return true;
        }
        return false;
    }
}
