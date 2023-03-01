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
    [SerializeField] private TMP_Text PriceText;
    [SerializeField] private RectTransform PriceRectTransform;
    [SerializeField] private Image IconImage;

    [TextArea(20, 20), SerializeField] private string Description;

    private int ElementLevel;
    private ShopItemLevel ShopItemLevel;
    private CoefficientCost CoefficientCost;
    private TMP_Text DescriptionText;
    private Button BuyButton;

    public void Init(int elementLevel, ShopItemLevel shopItemLevel, CoefficientCost coefficientCost, TMP_Text descriptionText, Button buyButton)
    {
        Image = GetComponent<Image>();
        Button = GetComponent<Button>();

        ElementLevel = elementLevel;
        ShopItemLevel = shopItemLevel;
        CoefficientCost = coefficientCost;
        DescriptionText = descriptionText;
        BuyButton = buyButton;

        Button.interactable = true;
        Button.onClick.AddListener(OnButtonClick);

        if (elementLevel <= shopItemLevel.Level)
        {
            Image.sprite = PurchasedImage;
            PriceText.text = "";
            IconImage.gameObject.SetActive(false);
            return;
        }

        Image.sprite = NotPurchasedImage;
        PriceText.text = coefficientCost.Cost.ToString();
        PriceRectTransform.sizeDelta = PriceText.GetPreferredValues();
    }

    private void OnButtonClick()
    {
        DescriptionText.text = Description;
        BuyButton.gameObject.SetActive(false);

        if (ElementLevel - ShopItemLevel.Level == 1)
        {
            BuyButton.gameObject.SetActive(true);
            BuyButton.onClick.RemoveAllListeners();
            BuyButton.onClick.AddListener(OnBuyButtonCkick);
        }
    }
    
    private void OnBuyButtonCkick()
    {
        if (CoefficientCost.Cost <= The.GameSession.Parameters.Money)
        {
            The.GameSession.ChangeMoney(-CoefficientCost.Cost);
            DescriptionText.text = "";
            BuyButton.onClick.RemoveAllListeners();
            BuyButton.gameObject.SetActive(false);
            ShopItemLevel.SetLevel(ElementLevel);
            Image.sprite = PurchasedImage;
            PriceText.text = "";
            IconImage.gameObject.SetActive(false);
        }
        
    }
}
