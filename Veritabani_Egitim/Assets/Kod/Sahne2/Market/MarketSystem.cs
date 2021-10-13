using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class MarketSystem : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform itemsParent;
    public List<MarketItemModel> marketItems;

    //MarketİtemTıklam
    public GameObject secilenItem;
    public GameObject satinAlmaPanel;
    public TextMeshProUGUI odenecekTutar_TMP, islemSonrasıTutar_TMP,satinAlmaSonucu_TMP;

    public float a, b; //clone posizyonları

    void Start()
    {
        //MarketItemModel item1 = new MarketItemModel("İtem 1 ","abc","75");

        // marketItems.Add(item1);
        itemleriGoster();
    }

    private void itemleriGoster()
    {
       for(int i = 0; i < marketItems.Count; i++)
        {
            GameObject cloneItem = Instantiate(itemPrefab);
            cloneItem.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = marketItems[i].itemAdi; //ad
            cloneItem.transform.GetChild(2).GetComponent<Image>().sprite= marketItems[i].templateResim; //resim
            cloneItem.transform.GetChild(3).GetComponentInChildren<TextMeshProUGUI>().text = "    "+marketItems[i].itemUcreti+"  "+"<sprite=0>";
    
            cloneItem.transform.SetParent(itemsParent);
            cloneItem.transform.localScale = new Vector3(1, 1, 1);
        }

    }

    public string urunFiyat;
    public int benimParam;
    public void satinAlmaPanelAc(GameObject ornekItem)
    {
        satinAlmaPanel.SetActive(true);
        ornekItem.transform.GetChild(3).gameObject.SetActive(false); //satinalma tusu pasif
        ornekItem.transform.SetParent(satinAlmaPanel.transform);
        ornekItem.transform.SetSiblingIndex(0); //panelin 1. çocuğu yapma
        ornekItem.GetComponent<RectTransform>().anchoredPosition = new Vector2(a, b); //İTEM paneldeki pozisyonu

        urunFiyat = ornekItem.transform.GetChild(3).GetComponentInChildren<TextMeshProUGUI>().text.TrimStart().Split(' ')[0].ToString();
        benimParam = GetComponent<ProfilBilgilerim>().paraGet();

        odenecekTutar_TMP.text = "" + urunFiyat + "  <sprite=0>";
        islemSonrasıTutar_TMP.text = "" + (benimParam- int.Parse(urunFiyat))+ "  <sprite=0>";
    }

    public void satinAlmaPanelKapat_B() //satin alma paneli kapatıp ilk çocugu siliyor tekrar görünmesin diye
    {
        Destroy(satinAlmaPanel.transform.GetChild(0).gameObject);
        satinAlmaPanel.SetActive(false);     
    }

    public void evet_B() {
        if (benimParam >= int.Parse(urunFiyat))
        {
            Debug.Log("BAKİYE var");
        }
        else
        {
            satinAlmaSonucu_TMP.text = "Yetersiz Bakiye";
        }
    }

    public void hayir_B()
    {
        satinAlmaPanelKapat_B();
    }
}

