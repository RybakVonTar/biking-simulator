using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {
    public BikeFrame bike;
    void Update() {
        transform.position = bike.transform.position + new Vector3(2, 2, -6);
    }
}
