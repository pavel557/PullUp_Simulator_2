using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Config")]
public class Config : ScriptableObject
{
    public List<CoefficientCost> FatiguePercentageAfterRepetition;
    public List<CoefficientCost> RecoveryPercentageAtEndOfDay;
    public List<CoefficientCost> EnergyGainBonusPercentageAtEndOfDay;
    public List<CoefficientCost> BasicAmountOfEffortForPullingUp;
    public List<CoefficientCost> TimeToLoseEnergyDuringPullUps;
}
