using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeWheels : MonoBehaviour {

    public BikeFrame bike;
    private HingeJoint2D hj;
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;

    void Start() {
        hj = GetComponent<HingeJoint2D>();
    }

    void Update() {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        var motor = hj.motor;
        motor.motorSpeed = horizontalInput * bike.speed;
        hj.motor = motor;
    }
    public bool GroundCheck() {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, maxDistance, layerMask)) {
            return true;
        }
        return false;
    }
}
