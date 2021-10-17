using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
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
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }

  
}
