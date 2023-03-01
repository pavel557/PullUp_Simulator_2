using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopElement : MonoBehaviour
{
    private Image Image;
    private Button Button;

    [SerializeField] private Sprite NotPurchasedImage;
    [SerializeField] private Sprite PurchasedImage;

    [TextArea(20, 20), SerializeField] private string Description;

    private int ElementLevel;
    private ShopItemLevel ShopItemLevel;
    private TMP_Text DescriptionText;
    private Button BuyButton;

    public void Init(int elementLevel, ShopItemLevel shopItemLevel, TMP_Text descriptionText, Button buyButton)
    {
        Image = GetComponent<Image>();
        Button = GetComponent<Button>();

        ElementLevel = elementLevel;
        ShopItemLevel = shopItemLevel;
        DescriptionText = descriptionText;
        BuyButton = buyButton;

        Button.interactable = true;
        Button.onClick.AddListener(OnButtonClick);

        if (elementLevel <= shopItemLevel.GetLevel())
        {
            Image.sprite = PurchasedImage;
            return;
        }

        Image.sprite = NotPurchasedImage;
    }

    private void OnButtonClick()
    {
        DescriptionText.text = Description;
        BuyButton.gameObject.SetActive(false);

        if (ElementLevel - ShopItemLevel.GetLevel() == 1)
        {
            BuyButton.gameObject.SetActive(true);
            BuyButton.onClick.RemoveAllListeners();
            BuyButton.onClick.AddListener(OnBuyButtonCkick);
        }
    }
    
    private void OnBuyButtonCkick()
    {
        DescriptionText.text = "";
        BuyButton.onClick.RemoveAllListeners();
        BuyButton.gameObject.SetActive(false);
        ShopItemLevel.SetLevel(ElementLevel);
        Debug.Log(ShopItemLevel.GetLevel());
        Debug.Log(The.ConfigManager.Shop.LevelFood.GetLevel());
        Image.sprite = PurchasedImage;
    }
}
