using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Callbacks;
using UnityEngine;

public class BikeFrame : MonoBehaviour {

    public int speed;
    public int jumpForce;
    public int tiltForce;
    private Rigidbody2D rb;
    private HingeJoint2D hj;
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        hj = GetComponent<HingeJoint2D>();
    }

    void Update() {
        SetTiltSpeed(0);
        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck()) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A) && !GroundCheck()) {
            SetTiltSpeed(-tiltForce);
        } else if (Input.GetKey(KeyCode.D) && !GroundCheck()) {
            SetTiltSpeed(tiltForce);
        }
    }

    private bool GroundCheck() {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, maxDistance, layerMask)) {
            return true;
        }
        return false;
    }

    private void SetTiltSpeed(int speed) {
        var motor = hj.motor;
        motor.motorSpeed = speed;
        hj.motor = motor;
    }
}
