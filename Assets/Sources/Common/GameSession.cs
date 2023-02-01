using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : Singleton<GameSession>
{
    public int Day;
    public int Money;

    public int MaxAmountEnergy;
    public int AmountFatigue;

    public int SumPullups;
    public int MaxPillups;
    public int MaxNumberRepetitions;
}
