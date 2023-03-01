using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopElementGroup : MonoBehaviour
{
    [SerializeField] private List<ShopElement> Elements = new List<ShopElement>();

    public void Init(ShopItemLevel shopItemLevel, TMP_Text descriptionText, Button buyButton)
    {
        for (var i=0; i<Elements.Count; i++) 
        {
            Elements[i].Init(i, shopItemLevel, descriptionText, buyButton);
        }
    }
}
