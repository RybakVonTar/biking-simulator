using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeWheels : MonoBehaviour {

    public BikeFrame bike;
    private HingeJoint2D hj;

    void Start() {
        hj = GetComponent<HingeJoint2D>();
    }

    void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        var motor = hj.motor;
        motor.motorSpeed = horizontalInput * bike.speed;
        hj.motor = motor;
    }
}
