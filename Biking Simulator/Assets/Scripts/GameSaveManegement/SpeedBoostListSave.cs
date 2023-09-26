using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SpeedBoostListSave {
    public List<bool> speedBoostList;
    public SpeedBoostListSave(List<bool> speedBoostList) {
        this.speedBoostList = speedBoostList;
    }
}