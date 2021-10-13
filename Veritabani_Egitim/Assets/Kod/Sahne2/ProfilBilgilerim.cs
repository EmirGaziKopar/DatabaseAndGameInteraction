using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProfilBilgilerim : MonoBehaviour
{
    public TextMeshProUGUI paraMiktar_TMP;
    private int paraMiktar;

    void Start()
    {
        paraMiktar = 250;
        miktarBastir();
    }

   
    void Update()
    {
        
    }

    public int paraGet() {
        return paraMiktar;
    }
    public void paraSet(int newPara)
    {
        paraMiktar = newPara;
    }

    public void miktarBastir()
    {
        paraMiktar_TMP.text = "" + paraGet() + "  <sprite=0>";
    }
}
