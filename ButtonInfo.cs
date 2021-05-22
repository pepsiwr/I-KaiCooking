using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    public int ItemID;
    public Text PrirceText;
    public Text QuantityText;
    public GameObject ShopManager;
    void Update()
    {
        PrirceText.text = "Price: $" + ShopManager.GetComponent<ShopManager>().shopItems[2, ItemID].ToString();
        QuantityText.text = ShopManager.GetComponent<ShopManager>().shopItems[3, ItemID].ToString();
    }
}
