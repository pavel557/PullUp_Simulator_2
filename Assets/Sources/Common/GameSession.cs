using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameSession : Singleton<GameSession>
{
    public GameSessionParameters Parameters { get; private set; }

    private string LEADERBOARD_ID = "CgkI6fXl7ocKEAIQAQ";

    public void Init()
    {
        Parameters = new GameSessionParameters();
    }

    public void Init(GameSessionParameters gameSessionParameters)
    {
        Parameters = gameSessionParameters;

        if (Parameters.CurrentAmountEnergy + Parameters.AmountFatigue != Parameters.MaxAmountEnergy)
        {
            Parameters.CurrentAmountEnergy = Parameters.MaxAmountEnergy - Parameters.AmountFatigue;
        }
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
            ChangeMaxPullups(The.PullupManager.CurrentAmountPullups);
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

    public void ChangeMaxPullups(int countPullups)
    {
        if (countPullups > Parameters.MaxPullups)
        {
            Parameters.MaxPullups = countPullups;
            Social.ReportScore(countPullups, LEADERBOARD_ID, ((bool success) => { }));
        }
    }
}
