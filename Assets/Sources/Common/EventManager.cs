using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public Action<int> DayChanged;
    public Action<int> MoneyChanged;

    //int : current, int : max
    public Action<int, int> AmountEnergyChanged;
    public Action<int> AmountFatigueChanged;

    public Action StartPullUp;
}
