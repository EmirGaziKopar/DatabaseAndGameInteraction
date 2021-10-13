using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class LoginSystem : MonoBehaviour
{

    public TMP_InputField kullaniciAdi_IF, sifre_IF;
    [Header("Deneme Kullanıcı")]
    public string isim = "selim";
    public string sifre = "123";

    PanelKontrol pK_Script;
    SahneGecis sahneGecis;
    void Start()
    {
        pK_Script = GetComponent<PanelKontrol>();
        sahneGecis = GameObject.Find("SahneManager").GetComponent<SahneGecis>();
    }

    public void girisYap_B() {
        if (kullaniciAdi_IF.text.Equals("") || sifre_IF.text.Equals("")) {
            StartCoroutine(pK_Script.hataPanel("Boş BIRAKMAYINIZ!"));
        }
        else
        {
            //veritabanı

           
            StartCoroutine(girisYap());
        }
    }

    IEnumerator girisYap()
    {
        WWWForm form = new WWWForm();
        form.AddField("unity", "girisYapma");
        form.AddField("kullaniciAdi", kullaniciAdi_IF.text); //selim
        form.AddField("sifre", sifre_IF.text);

        using (UnityWebRequest www = UnityWebRequest.Post("http://localhost/unity_DB/userRegister.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Sorgu Sonucu:" + www.downloadHandler.text);
                if (www.downloadHandler.text.Contains("1")) {
                     sahneGecis.sahneyiDegistir(1);
                }else
                StartCoroutine(pK_Script.hataPanel(www.downloadHandler.text));
            }
        }
    }



}
