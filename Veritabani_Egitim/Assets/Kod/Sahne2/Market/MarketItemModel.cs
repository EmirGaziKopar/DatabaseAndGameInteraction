using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MarketItemModel
{
    public string itemAdi;
    public string itemResimURL;
    public string itemUcreti;

    // 
    public Sprite templateResim;
    public MarketItemModel(string itemAdi,string itemResimURL,string itemUcreti,Sprite templateResim) {
        this.itemAdi = itemAdi;
        this.itemResimURL = itemResimURL;
        this.itemUcreti = itemUcreti;
        this.templateResim = templateResim;
    }
}
