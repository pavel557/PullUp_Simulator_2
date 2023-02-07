using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CounterPullup : MonoBehaviour
{
    [SerializeField] private TMP_Text CounterPullupText;

    public void Init()
    {
        The.EventManager.StartPullUp += () => ChangeCounterPullupText(0);
        The.EventManager.PullUp += () => ChangeCounterPullupText(The.PullupManager.CurrentAmountPullups);
        The.EventManager.EndPullUp += () => ChangeCounterPullupText("");
    }

    private void ChangeCounterPullupText(int value)
    {
        CounterPullupText.text = value.ToString();
    }

    private void ChangeCounterPullupText(string value)
    {
        CounterPullupText.text = value;
    }
}
