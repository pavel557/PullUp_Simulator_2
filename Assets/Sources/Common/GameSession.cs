using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MessagePack;


public class GameSession : Singleton<GameSession>
{
    public GameSessionParameters Parameters { get; private set; }

    public void Init()
    {
        Parameters = new GameSessionParameters();
    }

    public void Init(GameSessionParameters gameSessionParameters)
    {
        Parameters = gameSessionParameters;
    }

    public void ChangeDay()
    {
        Parameters.Day++;
        ChangeMaxAmountEnergy(The.PullupManager.SumPullups);

        int amountFatigue = CalculateFatigueChange();
        ChangeAmountFatigue(-amountFatigue);
        SetCurrentAmountEnergy(Parameters.MaxAmountEnergy - Parameters.AmountFatigue);

        The.EventManager.DayChanged(Parameters.Day);
    }

    public void ChangeMoney(int valueChange)
    {
        Parameters.Money += valueChange;
        The.EventManager.MoneyChanged(Parameters.Money);
    }

    public void ChangeMaxAmountEnergy(int valueChange)
    {
        Parameters.MaxAmountEnergy += valueChange;
        The.EventManager.AmountEnergyChanged(Parameters.CurrentAmountEnergy, Parameters.MaxAmountEnergy);
    }

    public void ChangeCurrentAmountEnergy(int valueChange)
    {
        Parameters.CurrentAmountEnergy += valueChange;
        The.EventManager.AmountEnergyChanged(Parameters.CurrentAmountEnergy, Parameters.MaxAmountEnergy);

        if (Parameters.CurrentAmountEnergy <= 0)
        {
            The.EventManager.EndPullUp?.Invoke();

            int amountFatigue = Mathf.RoundToInt(Parameters.MaxAmountEnergy * The.ConfigManager.GetFatiguePercentageAfterRepetition());
            ChangeAmountFatigue(amountFatigue);

            SetCurrentAmountEnergy(Parameters.MaxAmountEnergy - Parameters.AmountFatigue);
        }
    }

    public void SetCurrentAmountEnergy(int value)
    {
        Parameters.CurrentAmountEnergy = value;
        The.EventManager.AmountEnergyChanged(Parameters.CurrentAmountEnergy, Parameters.MaxAmountEnergy);
    }

    public void ChangeAmountFatigue(int valueChange)
    {
        Parameters.AmountFatigue += valueChange;

        if (Parameters.AmountFatigue >= Parameters.MaxAmountEnergy)
        {
            Parameters.AmountFatigue = Parameters.MaxAmountEnergy - 1;
        }

        if (Parameters.AmountFatigue < 0)
        {
            Parameters.AmountFatigue = 0;
        }

        The.EventManager.AmountFatigueChanged(Parameters.AmountFatigue);
    }

    public int CalculateFatigueChange()
    {
        return Mathf.RoundToInt(Parameters.MaxAmountEnergy * The.ConfigManager.GetRecoveryPercentageAtEndOfDay());
    }
}

[MessagePackObject]
public class GameSessionParameters
{
    [Key(0)] public int Day { get; set; }
    [Key(1)] public int Money { get; set; }
    [Key(2)] public int MaxAmountEnergy { get; set; }
    [Key(3)] public int CurrentAmountEnergy { get; set; }
    [Key(4)] public int AmountFatigue { get; set; }
    [Key(5)] public int MaxPullups { get; set; }
    [Key(6)] public int MaxNumberRepetitions { get; set; }

    public GameSessionParameters()
    {
        Day = 1;
        Money = 0;
        MaxAmountEnergy = 100;
        CurrentAmountEnergy = 100;
        AmountFatigue = 0;

        MaxPullups = 0;
        MaxNumberRepetitions = 0;
    }
}
