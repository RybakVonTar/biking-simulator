using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour {

    public BikeFrame bike;

    void Update() {
        transform.position = bike.transform.position;
    }
}
