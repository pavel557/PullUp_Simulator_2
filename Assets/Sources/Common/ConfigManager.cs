using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigManager : Singleton<ConfigManager>
{
    public Config Config;
    public Shop Shop;

    public void Init(Shop shop)
    {
        Config = Resources.Load<Config>("Configs/Config");
        Shop = shop;
    }

    public float GetFatiguePercentageAfterRepetition()
    {
        return Config.FatiguePercentageAfterRepetition[Shop.LevelHorizontalBar.Level].Coefficient;
    }

    public float GetRecoveryPercentageAtEndOfDay()
    {
        return Config.RecoveryPercentageAtEndOfDay[Shop.LevelBed.Level].Coefficient;
    }

    public float GetEnergyGainBonusPercentageAtEndOfDay()
    {
        return Config.EnergyGainBonusPercentageAtEndOfDay[Shop.LevelFood.Level].Coefficient;
    }

    public int GetBasicAmountOfEffortForPullingUp()
    {
        return Mathf.RoundToInt(Config.BasicAmountOfEffortForPullingUp[Shop.LevelCloth.Level].Coefficient);
    }

    public float GetTimeToLoseEnergyDuringPullUps()
    {
        return Config.TimeToLoseEnergyDuringPullUps[Shop.LevelMusic.Level].Coefficient;
    }
}
