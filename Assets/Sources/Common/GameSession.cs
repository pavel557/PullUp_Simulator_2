using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : Singleton<GameSession>
{
    public int Day { get; private set; }
    public int Money { get; private set; }
    public int MaxAmountEnergy { get; private set; }
    public int CurrentAmountEnergy { get; private set; }
    public int AmountFatigue { get; private set; }
    public int MaxPullups { get; private set; }
    public int MaxNumberRepetitions { get; private set; }

    public void Init()
    {
        Day = 1;
        Money = 0;
        MaxAmountEnergy = 100;
        CurrentAmountEnergy = 100;
        AmountFatigue = 0;

        MaxPullups = 0;
        MaxNumberRepetitions = 0;
    }

    public void Init(int day, int money, int maxAmountEnergy, int currentAmountEnergy, int amountFatigue, int sumPullups, int maxPullups, int maxNumberRepetitions)
    {
        Day = day;
        Money = money;
        MaxAmountEnergy = maxAmountEnergy;
        CurrentAmountEnergy = currentAmountEnergy;
        AmountFatigue = amountFatigue;

        MaxPullups = maxPullups;
        MaxNumberRepetitions = maxNumberRepetitions;
    }

    public void ChangeDay()
    {
        Day++;
        ChangeMaxAmountEnergy(The.PullupManager.SumPullups);

        int amountFatigue = CalculateFatigueChange();
        ChangeAmountFatigue(-amountFatigue);
        SetCurrentAmountEnergy(MaxAmountEnergy - AmountFatigue);

        The.EventManager.DayChanged(Day);
    }

    public void ChangeMoney(int valueChange)
    {
        Money += valueChange;
        The.EventManager.MoneyChanged(Money);
    }

    public void ChangeMaxAmountEnergy(int valueChange)
    {
        MaxAmountEnergy += valueChange;
        The.EventManager.AmountEnergyChanged(CurrentAmountEnergy, MaxAmountEnergy);
    }

    public void ChangeCurrentAmountEnergy(int valueChange)
    {
        CurrentAmountEnergy += valueChange;
        The.EventManager.AmountEnergyChanged(CurrentAmountEnergy, MaxAmountEnergy);

        if (CurrentAmountEnergy <= 0)
        {
            The.EventManager.EndPullUp?.Invoke();

            int amountFatigue = Mathf.RoundToInt(MaxAmountEnergy * The.ConfigManager.GetFatiguePercentageAfterRepetition());
            ChangeAmountFatigue(amountFatigue);

            SetCurrentAmountEnergy(MaxAmountEnergy - AmountFatigue);
        }
    }

    public void SetCurrentAmountEnergy(int value)
    {
        CurrentAmountEnergy = value;
        The.EventManager.AmountEnergyChanged(CurrentAmountEnergy, MaxAmountEnergy);
    }

    public void ChangeAmountFatigue(int valueChange)
    {
        AmountFatigue += valueChange;

        if (AmountFatigue >= MaxAmountEnergy)
        {
            AmountFatigue = MaxAmountEnergy - 1;
        }

        if (AmountFatigue < 0)
        {
            AmountFatigue = 0;
        }

        The.EventManager.AmountFatigueChanged(AmountFatigue);
    }

    public int CalculateFatigueChange()
    {
        return Mathf.RoundToInt(MaxAmountEnergy * The.ConfigManager.GetRecoveryPercentageAtEndOfDay());
    }
}
