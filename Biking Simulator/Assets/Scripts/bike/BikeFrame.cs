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
    private Rigidbody2D rb;
    public BikeWheels frontWheel;
    public BikeWheels backWheel;
    public bool doubleJump;
    public bool speedBoost;
    public float speedBoostTimer;
    public int speedBoostValue;
    public Vector3 boxSize;
    public float maxDistance;
    public LayerMask layerMask;

    public EscapeHandler escape;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        speedBoostTimer = 0;

        escape = FindObjectOfType<EscapeHandler>();

        LoadSave load = JsonUtility.FromJson<LoadSave>(FileManager.LoadFromFile("loadSaveData.json"));
        if (load != null && load.load) {
            LoadSave();
        }
    }

    void Update() {

        if (!escape.menu) {
            if (Input.GetKeyDown(KeyCode.Space) && (backWheel.GroundCheck() || frontWheel.GroundCheck())) {
                rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                tiltForce = 0;

            } else if (Input.GetKeyDown(KeyCode.Space) && doubleJump) {
                doubleJump = false;
                rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
                tiltForce = 0;
            }

            if (Input.GetKey(KeyCode.A) && !(backWheel.GroundCheck() || frontWheel.GroundCheck())) {
                rb.angularVelocity = 0;
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
    }

    private void LoadSave() { 
        string json_bike = FileManager.LoadFromFile("bikeSaveData.json");
        JsonUtility.FromJsonOverwrite(json_bike, this);
        BikeWheels[] wheelsList = FindObjectsOfType<BikeWheels>();

        for (int i = 0; i < wheelsList.Length; i += 1) {
            if (wheelsList[i].CompareTag("frontWheel")) {
                frontWheel = wheelsList[i];
            } else {
                backWheel = wheelsList[i];
            }
        }
        transform.position = position;

        string json_coins = FileManager.LoadFromFile("coinsSaveData.json");
        CoinListSave coinsListLoaded = JsonUtility.FromJson<CoinListSave>(json_coins);
        CoinCollectible[] coinsListNow = FindObjectsOfType<CoinCollectible>();
        for (int i = 0; i < coinsListLoaded.coinList.Count; i += 1) {
            coinsListNow[i].collected = coinsListLoaded.coinList[i];
        }  

        string json_speedBoost = FileManager.LoadFromFile("speedBoostSaveData.json");
        SpeedBoostListSave speedBoostListLoaded = JsonUtility.FromJson<SpeedBoostListSave>(json_speedBoost);
        SpeedBoostCollectible[] speedBoostListNow = FindObjectsOfType<SpeedBoostCollectible>();
        for (int i = 0; i < speedBoostListLoaded.speedBoostList.Count; i += 1) {
            speedBoostListNow[i].collected = speedBoostListLoaded.speedBoostList[i];
        }  
        
        string json_doubleJump = FileManager.LoadFromFile("doubleJumpSaveData.json");
        DoubleJumpListSave doubleJumpListLoaded = JsonUtility.FromJson<DoubleJumpListSave>(json_doubleJump);
        DoubleJumpCollectible[] doubleJumpListNow = FindObjectsOfType<DoubleJumpCollectible>();
        for (int i = 0; i < doubleJumpListLoaded.doubleJumpList.Count; i += 1) {
            doubleJumpListNow[i].collected = doubleJumpListLoaded.doubleJumpList[i];
        }
    }

    public bool GroundCheck() {
        if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, maxDistance, layerMask)) {
            return true;
        }
        return false;
    }
}
