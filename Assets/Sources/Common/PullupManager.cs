using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullupManager : Singleton<PullupManager>
{
    public int CurrentAmountOfEffort { get; private set; }

    public int RequiredAmountOfEffort { get; private set; }

    public Coroutine DecreaseForce;

    private float ReloadingDecreaseForce;

    public void Init()
    {
        CurrentAmountOfEffort = 0;
        RequiredAmountOfEffort = The.ConfigManager.GetBasicAmountOfEffortForPullingUp();
        ReloadingDecreaseForce = The.ConfigManager.GetTimeToLoseEnergyDuringPullUps();
    }

    public void ChangeCurrentForce(int valueChange)
    {
        CurrentAmountOfEffort += valueChange;

        if (CurrentAmountOfEffort < 0)
        {
            CurrentAmountOfEffort = 0;
            return;
        }

        if (CurrentAmountOfEffort >= RequiredAmountOfEffort)
        {
            The.EventManager.PullUp?.Invoke();

            CurrentAmountOfEffort = 0;
            
            //дописать формулу
            RequiredAmountOfEffort = The.ConfigManager.GetBasicAmountOfEffortForPullingUp();
        }
    }

    public IEnumerator DecreaseForceCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(ReloadingDecreaseForce);
            ChangeCurrentForce(-1);
            The.GameSession.ChangeCurrentAmountEnergy(-1);
        }
    }
}
