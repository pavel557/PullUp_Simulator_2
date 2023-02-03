using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : Singleton<GameSession>
{
    public int Day
    {
        get => Day;
        set
        {
            Day = value;
            The.EventManager.DayChanged?.Invoke(Day);
        }
    }
    public int Money
    {
        get => Money;
        set
        {
            Money = value;
            The.EventManager.MoneyChanged?.Invoke(Money);
        }
    }

    public int MaxAmountEnergy
    {
        get => MaxAmountEnergy;
        set
        {
            MaxAmountEnergy = value;
            The.EventManager.AmountEnergyChanged?.Invoke(CurrentAmountEnergy, MaxAmountEnergy);
        }
    }

    public int CurrentAmountEnergy
    {
        get => CurrentAmountEnergy;
        set
        {
            CurrentAmountEnergy = value;
            The.EventManager.AmountEnergyChanged?.Invoke(CurrentAmountEnergy, MaxAmountEnergy);
        }
    }

    public int AmountFatigue
    {
        get => AmountFatigue;
        set
        {
            AmountFatigue = value;
            The.EventManager.AmountFatigueChanged?.Invoke(AmountFatigue);
        }
    }

    public int SumPullups;
    public int MaxPillups;
    public int MaxNumberRepetitions;
}
