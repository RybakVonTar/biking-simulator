using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCheck : MonoBehaviour {

    public BoxCollider2D col;
    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("ground")) {
            Debug.Log("DEAD");
        }
        
    }
}
