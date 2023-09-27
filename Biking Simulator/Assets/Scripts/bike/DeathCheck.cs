using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCheck : MonoBehaviour {

    public EscapeHandler escapeHandler;
    void OnTriggerEnter2D(Collider2D collider) {
        escapeHandler.death = collider.CompareTag("ground");
    }
}
