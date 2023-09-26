using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CoinListSave {
    public List<bool> coinList;
    public CoinListSave(List<bool> coinList) {
        this.coinList = coinList;
    }
}