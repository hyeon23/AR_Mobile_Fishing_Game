using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventoryManager : MonoBehaviour
{

    public TextMeshProUGUI goldNum; 
    void Start()
    {
        SaveCtrl.instance.ResetData(5);
        
        goldNum.text = SaveCtrl.instance.myData.gold.ToString();

    }

    
}
