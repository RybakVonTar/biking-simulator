using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeWheels : MonoBehaviour {

    public BikeFrame bike;

    void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        HingeJoint2D hinge = GetComponent<HingeJoint2D>();

        var motor = hinge.motor;
        motor.motorSpeed = horizontalInput * bike.speed;
        hinge.motor = motor;
    }
}
