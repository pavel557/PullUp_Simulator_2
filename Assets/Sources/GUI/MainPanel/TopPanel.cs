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
        ChangeDayText(The.GameSession.Parameters.Day);
        ChangeMoneyText(The.GameSession.Parameters.Money);

        The.EventManager.DayChanged += ChangeDayText;
        The.EventManager.MoneyChanged += ChangeMoneyText;
    }

    private void ChangeDayText(int value)
    {
        DayText.text = "���� " + value;
    }

    private void ChangeMoneyText(int value)
    {
        MoneyText.text = value.ToString();
    }    
}
