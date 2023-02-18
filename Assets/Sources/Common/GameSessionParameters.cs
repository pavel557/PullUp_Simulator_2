using MessagePack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
