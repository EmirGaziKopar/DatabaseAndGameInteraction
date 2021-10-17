using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

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

           
            StartCoroutine(girisYap()); //IEnumerator türünde fonksiyonları çağırmak için StartCoroutine() kullanılır.
        }
    }

    IEnumerator girisYap()
    {
        WWWForm form = new WWWForm();

        form.AddField("unity", "girisYapma"); //php ekranında $_POST['unity']==kayitOlma ise diye kontrol kullanıcı bu işlemi yaptığı taktirde aşağıdaki girdileri yollama işlemini php tarafında gerçekleştireceğiz.
        form.AddField("kullaniciAdi", kullaniciAdi_IF.text);
        form.AddField("sifre", sifre_IF.text);


        //Burada bulunan URI'a POST işlemi yapılsın
        UnityWebRequest www = UnityWebRequest.Post("http://localhost/game/veritabani/baglanti.php", form); //yukaridaki veriler buradaki uri'a gönderilecek
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success) //Veriler başarılı bir şekilde gönderildi 
        {
            Debug.Log(www.error);
        }
        else
        {
            /*if(www.downloadHandler.text == "tebrikler")
            {
                StartCoroutine(pK_Script.hataPanel(www.downloadHandler.text));
            }
            else
            {
                //StartCoroutine(pK_Script.hataPanel(www.downloadHandler.text)); //tuhaf bir hata mesajı yazdırdığı için bunu kapattım
                StartCoroutine(pK_Script.hataPanel("Bu isim zaten kullanılıyor"));
            }
            Debug.Log("Sorgu Sonucu : "+www.downloadHandler.text); //+www.downloadHandler.text php ekranında donen herhangi birşey varsa onu basaca
             //php'den echo ile dönen text degeri */


            if(www.downloadHandler.text.Contains("Giris Basarili")) //www'dan gelen text çağrısı bu şekilde kontrol edilebilir giris basarılı ise true doner
            {
                SceneManager.LoadScene(1, LoadSceneMode.Single);
            }

            StartCoroutine(pK_Script.hataPanel(www.downloadHandler.text));
        }
    }



}
