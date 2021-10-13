using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;


public class ButtonTiklama : MonoBehaviour, IPointerClickHandler
{

    MarketSystem marketSystem;

    void Start() {
        marketSystem = GameObject.Find("GameManager").GetComponent<MarketSystem>();
    }
   

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("" + gameObject.GetComponentInChildren<TextMeshProUGUI>().text.TrimStart().Split(' ')[0]);
        marketSystem.secilenItem = gameObject.transform.parent.transform.gameObject; //game objecti baska bir gameobjette aldım
        
        marketSystem.satinAlmaPanelAc(Instantiate(marketSystem.secilenItem)); //instantete edilen clone fonksiyona geçtim
    }
}
