using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCheck : MonoBehaviour {

    public BoxCollider2D col;
    void OnTriggerEnter2D() {
        Debug.Log("DEAD");
        //SceneManager.LoadScene(sceneName: "Menu");
    }
}
