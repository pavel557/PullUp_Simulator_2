using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnergyPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text EnergyText;
    [SerializeField] private TMP_Text FatigueText;

    [SerializeField] private Image EnergyBar;
    [SerializeField] private Image FatigueBar;

    public void Init()
    {
        ChangeEnergy(The.GameSession.CurrentAmountEnergy, The.GameSession.MaxAmountEnergy);
        ChangeFatigue(The.GameSession.AmountFatigue);

        The.EventManager.AmountEnergyChanged += ChangeEnergy;
        The.EventManager.AmountFatigueChanged += ChangeFatigue;
    }

    private void ChangeEnergy(int value, int maxValue)
    {
        EnergyText.text = value + "/" + maxValue;
        EnergyBar.fillAmount = (float)value / maxValue;
    }

    private void ChangeFatigue(int value)
    {
        FatigueText.text = value.ToString();
        FatigueBar.fillAmount = (float)value / The.GameSession.MaxAmountEnergy;
    }
}
