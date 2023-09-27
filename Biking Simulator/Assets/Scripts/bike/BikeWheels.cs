using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeWheels : MonoBehaviour {

    public BikeFrame bike;
    private HingeJoint2D hj;
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;

    public EscapeHandler escape;

    void Start() {
        hj = GetComponent<HingeJoint2D>();
        escape = FindObjectOfType<EscapeHandler>();
    }

    void Update() {
        if (!escape.menu) {
            float horizontalInput = Input.GetAxis("Horizontal");
        
            var motor = hj.motor;
            motor.maxMotorTorque = bike.motorTorque;
            motor.motorSpeed = horizontalInput * bike.speed;
            hj.motor = motor;
        }
        else {
            float horizontalInput = 0;

            var motor = hj.motor;
            motor.maxMotorTorque = bike.motorTorque;
            motor.motorSpeed = horizontalInput * bike.speed;
            hj.motor = motor;
        }
    }
    public bool GroundCheck() {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, maxDistance, layerMask)) {
            return true;
        }
        return false;
    }
}
