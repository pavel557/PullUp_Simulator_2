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
        return Config.FatiguePercentageAfterRepetition[Shop.LevelHorizontalBar.GetLevel()];
    }

    public float GetRecoveryPercentageAtEndOfDay()
    {
        return Config.RecoveryPercentageAtEndOfDay[Shop.LevelBed.GetLevel()];
    }

    public float GetEnergyGainBonusPercentageAtEndOfDay()
    {
        return Config.EnergyGainBonusPercentageAtEndOfDay[Shop.LevelFood.GetLevel()];
    }

    public int GetBasicAmountOfEffortForPullingUp()
    {
        return Config.BasicAmountOfEffortForPullingUp[Shop.LevelCloth.GetLevel()];
    }

    public float GetTimeToLoseEnergyDuringPullUps()
    {
        return Config.TimeToLoseEnergyDuringPullUps[Shop.LevelMusic.GetLevel()];
    }
}
