using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro; //TextMeshPro İçin
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;//UI objeleri için


public class RegisterSystem : MonoBehaviour
{

    public TMP_InputField kullaniciAdi_IF, sifre_IF, sifreTekrar_IF;
    public Toggle sozlesme;

    PanelKontrol pK_Script;

    

    void Start()
    {
        pK_Script = GetComponent<PanelKontrol>();
    }

 
    void Update()
    {
        
    }


    public void uyeligiOlustur_B() {
        if (kullaniciAdi_IF.text.Equals("") || sifre_IF.text.Equals("") || sifreTekrar_IF.text.Equals(""))
        {
                StartCoroutine(pK_Script.hataPanel("Boş BIRAKMAYINIZ!"));
          
        }
        else {

            if (sifre_IF.text.Equals(sifreTekrar_IF.text))
            {
                if (sozlesme.isOn)
                {
                    Debug.Log("Veritabanı Bağlantısı");
                    StartCoroutine(kayitOl());
                   
                }
                else
                {
                    StartCoroutine(pK_Script.hataPanel("Sözleşmeyi Kabul Ediniz!"));
                }
            }
            else
            {
                StartCoroutine(pK_Script.hataPanel("Şifreler Eşleşmiyor!"));
                
            }
        }
    }



    IEnumerator kayitOl()
    {
        WWWForm form = new WWWForm();

        form.AddField("unity", "kayitOlma"); //php ekranında $_POST['unity']==kayitOlma ise diye kontrol kullanıcı bu işlemi yaptığı taktirde aşağıdaki girdileri yollama işlemini php tarafında gerçekleştireceğiz.
        form.AddField("kullaniciAdi",kullaniciAdi_IF.text);
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

            StartCoroutine(pK_Script.hataPanel(www.downloadHandler.text));
        }
    }



}

	