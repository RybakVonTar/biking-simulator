using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeWheels : MonoBehaviour {

    public BikeFrame bike;
    private HingeJoint2D hinge;

    void Start() {
        hinge = GetComponent<HingeJoint2D>();
    }

    void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        var motor = hinge.motor;
        motor.motorSpeed = horizontalInput * bike.speed;
        hinge.motor = motor;
    }
}
