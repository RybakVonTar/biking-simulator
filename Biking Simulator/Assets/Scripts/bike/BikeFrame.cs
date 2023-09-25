using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeFrame : MonoBehaviour {
    public Vector3 position;
    public int speed;
    public int motorTorque;
    public int jumpForce;
    public float tiltAcceleration;
    public float tiltForce;
    public float maxTiltForce;
    public Rigidbody2D rb;
    public BikeWheels frontWheel;
    public BikeWheels backWheel;
    public bool doubleJump;
    public bool speedBoost;
    public float speedBoostTimer;
    public int speedBoostValue;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        speedBoostTimer = 0;/*
        LoadSave load = JsonUtility.FromJson<LoadSave>(FileManager.LoadFromFile("loadSaveData.json"));
        if (load != null) {
            LoadSave();
        }*/
    }

    void Update() {
        
        if (Input.GetKeyDown(KeyCode.Space) && (backWheel.GroundCheck() || frontWheel.GroundCheck())) {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            tiltForce = 0;

        } else if (Input.GetKeyDown(KeyCode.Space) && doubleJump) {
            doubleJump = false;
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

        } else if (Input.GetKey(KeyCode.W) && speedBoost) {
            motorTorque += speedBoostValue;
            speedBoost = false;
            speedBoostTimer = 3;
        }
        

        if (speedBoostTimer > 0) {
            speedBoostTimer -= Time.deltaTime;

            if (speedBoostTimer <= 0) {
                motorTorque -= speedBoostValue;
            }
        } 
    }

    void LoadSave() { 
        FileManager.LoadFromFile("bikeSaveData.json");
        string json_bike = FileManager.LoadFromFile("bikeSaveData.json");
        JsonUtility.FromJsonOverwrite(json_bike, this);
    }
}
