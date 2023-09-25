using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Callbacks;
using UnityEngine;

public class BikeFrame : MonoBehaviour {

    public int speed;
    public int jumpForce;
    public float tiltAcceleration;
    private float tiltForce;
    public float maxTiltForce;
    private Rigidbody2D rb;
    public BikeWheels frontWheel;
    public BikeWheels backWheel;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        
        if (Input.GetKeyDown(KeyCode.Space) && (backWheel.GroundCheck() || frontWheel.GroundCheck())) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            tiltForce = 0;
        }

        if (Input.GetKey(KeyCode.A) && !(backWheel.GroundCheck() || frontWheel.GroundCheck())) {
            if (tiltForce < maxTiltForce) {
                tiltForce += tiltAcceleration;
            }
            transform.Rotate(0, 0, tiltForce);

        } else if (Input.GetKey(KeyCode.D) && !(backWheel.GroundCheck() || frontWheel.GroundCheck())) {
            if (tiltForce < maxTiltForce) {
                tiltForce += tiltAcceleration;
            }
            transform.Rotate(0, 0, -tiltForce);
        }
    }
}
