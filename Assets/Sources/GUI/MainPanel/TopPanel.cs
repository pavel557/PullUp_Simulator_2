using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TopPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text DayText;
    [SerializeField] private TMP_Text MoneyText;

    public void Init()
    {
        DayText.text = "Δενό " + The.GameSession.Day;
        MoneyText.text = The.GameSession.Money.ToString();

        The.EventManager.DayChanged += ChangeDayText;
        The.EventManager.MoneyChanged += ChangeMoneyText;
    }

    private void ChangeDayText(int value)
    {
        DayText.text = "Δενό " + value;
    }

    private void ChangeMoneyText(int value)
    {
        MoneyText.text = The.GameSession.Money.ToString();
    }    
}
