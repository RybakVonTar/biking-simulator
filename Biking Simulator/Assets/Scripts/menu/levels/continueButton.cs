using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class continueButton : MonoBehaviour
{
    public EscapeHandler script;

    void Start() {
       script = FindObjectOfType<EscapeHandler>();
       Button btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick() {
        script.menu = false;
    }
}
