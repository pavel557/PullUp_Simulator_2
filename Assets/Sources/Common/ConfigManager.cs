using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : Singleton<ConfigManager>
{
    public Config Config;

    public int IndexFatiguePercentageAfterRepetition;
    public int IndexRecoveryPercentageAtEndOfDay;
    public int IndexEnergyGainBonusPercentageAtEndOfDay;
    public int IndexBasicAmountOfEffortForPullingUp;
    public int IndexTimeToLoseEnergyDuringPullUps;

    public void Init()
    {
        Config = Resources.Load<Config>("Configs/Config");

        IndexFatiguePercentageAfterRepetition = 0;
        IndexRecoveryPercentageAtEndOfDay = 0;
        IndexEnergyGainBonusPercentageAtEndOfDay = 0;
        IndexBasicAmountOfEffortForPullingUp = 0;
        IndexTimeToLoseEnergyDuringPullUps = 0;
    }

    public float GetFatiguePercentageAfterRepetition()
    {
        return Config.FatiguePercentageAfterRepetition[IndexFatiguePercentageAfterRepetition];
    }

    public int GetBasicAmountOfEffortForPullingUp()
    {
        return Config.BasicAmountOfEffortForPullingUp[IndexBasicAmountOfEffortForPullingUp];
    }

    public float GetTimeToLoseEnergyDuringPullUps()
    {
        return Config.TimeToLoseEnergyDuringPullUps[IndexTimeToLoseEnergyDuringPullUps];
    }
}
