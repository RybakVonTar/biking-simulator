using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathCheck : MonoBehaviour {

    void OnTriggerEnter() {
        Debug.Log("DEAD");
        SceneManager.LoadScene(sceneName: "Menu");
    }
}
