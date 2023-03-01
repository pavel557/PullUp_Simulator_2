using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] private Button BackButton;
    [SerializeField] private Button BuyButton;
    [SerializeField] private TMP_Text DescriptionText;
    [SerializeField] private ShopElementGroup FoodElementGroup;
    [SerializeField] private ShopElementGroup HorizontalBarElementGroup;
    [SerializeField] private ShopElementGroup BedGroupElementGroup;

    public void Init()
    {
        BackButton.interactable = true;
        BuyButton.gameObject.SetActive(false);

        BackButton.onClick.AddListener(() => Destroy(this.gameObject));

        FoodElementGroup.Init(The.ConfigManager.Shop.LevelFood, DescriptionText, BuyButton);
        HorizontalBarElementGroup.Init(The.ConfigManager.Shop.LevelHorizontalBar, DescriptionText, BuyButton);
        BedGroupElementGroup.Init(The.ConfigManager.Shop.LevelBed, DescriptionText, BuyButton);
    }
}
