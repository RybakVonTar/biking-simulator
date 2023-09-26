using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DoubleJumpListSave {
    public List<bool> doubleJumpList;
    public DoubleJumpListSave(List<bool> doubleJumpList) {
        this.doubleJumpList = doubleJumpList;
    }
}