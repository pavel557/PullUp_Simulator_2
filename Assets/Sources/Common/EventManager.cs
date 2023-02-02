using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public Action<int> DayChanged;
    public Action<int> MoneyChanged;

    public Action<int> MaxAmountEnergyChanged;
    public Action<int> CurrentAmountEnergyChanged;
    public Action<int> AmountFatigueChanged;
}
