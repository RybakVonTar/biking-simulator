using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCheck : MonoBehaviour {

    public EscapeHandler escapeHandler;
    void OnCollisionEnter2D(Collision2D collision) {
        escapeHandler.death = collision.gameObject.CompareTag("ground");
        Debug.Log(escapeHandler.death);
        Destroy(this);
    }
}
