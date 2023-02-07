using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullupManager : Singleton<PullupManager>
{
    public int CurrentAmountOfEffort { get; private set; }
    public int RequiredAmountOfEffort { get; private set; }
    public int CurrentAmountPullups { get; private set; }

    public Coroutine DecreaseForce;

    private float ReloadingDecreaseForce;

    public void Init()
    {
        CurrentAmountOfEffort = 0;
        RequiredAmountOfEffort = The.ConfigManager.GetBasicAmountOfEffortForPullingUp();
        CurrentAmountPullups = 0;

        ReloadingDecreaseForce = The.ConfigManager.GetTimeToLoseEnergyDuringPullUps();

        The.EventManager.EndPullUp += () => { CurrentAmountPullups = 0; };
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
            The.GameSession.ChangeMoney(1);
            CurrentAmountPullups++;

            CurrentAmountOfEffort = 0;

            //дописать формулу
            RequiredAmountOfEffort = The.ConfigManager.GetBasicAmountOfEffortForPullingUp();

            The.EventManager.PullUp?.Invoke();
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
