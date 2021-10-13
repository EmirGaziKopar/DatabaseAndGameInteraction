using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class EkrandakiButonlar : MonoBehaviour
{
    ProfilBilgilerim profilBilgilerim;


    private void Start()
    {
        profilBilgilerim = GetComponent<ProfilBilgilerim>();
    }
    public void azalt()
    {
        profilBilgilerim.paraSet(profilBilgilerim.paraGet() - 5);
        profilBilgilerim.miktarBastir();
        Debug.Log("Azalttım");

    }
    public void arttir()
    {
        profilBilgilerim.paraSet(profilBilgilerim.paraGet() + 8);
        profilBilgilerim.miktarBastir();
        Debug.Log("Arttirdım");
    }
    public void geri()
    {
        GameObject.Find("SahneManager").GetComponent<SahneGecis>().sahneyiDegistir(0);
    }

  
}
