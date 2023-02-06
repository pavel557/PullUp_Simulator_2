using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Configs/Config")]
public class Config : ScriptableObject
{
    public List<float> FatiguePercentageAfterRepetition;
    public List<float> RecoveryPercentageAtEndOfDay;
    public List<float> EnergyGainBonusPercentageAtEndOfDay;
    public List<int> BasicAmountOfEffortForPullingUp;
    public List<float> TimeToLoseEnergyDuringPullUps;
}
