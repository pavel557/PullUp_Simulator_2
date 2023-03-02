using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopElementGroup : MonoBehaviour
{
    [SerializeField] private List<ShopElement> Elements = new List<ShopElement>();

    public void Init(ShopItemLevel shopItemLevel, List<CoefficientCost> coefficientCosts, TMP_Text descriptionText, Button buyButton, bool hasStartItem = false)
    {
        for (var i = 0; i<Elements.Count; i++) 
        {
            var index = hasStartItem ? i : i + 1;
            Elements[i].Init(index, shopItemLevel, coefficientCosts[index], descriptionText, buyButton);
        }
    }
}
