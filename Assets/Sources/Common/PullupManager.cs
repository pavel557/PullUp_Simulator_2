using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PullupManager : Singleton<PullupManager>
{
    public int CurrentForce { get; private set; }

    public int RequiredForce { get; private set; }

    private float ReloadingDecreaseForce;

    public void Init()
    {
        CurrentForce = 0;
        RequiredForce = 5;
        ReloadingDecreaseForce = 1f;
    }

    public void ChangeCurrentForce(int valueChange)
    {
        CurrentForce += valueChange;

        if (CurrentForce < 0)
        {
            CurrentForce = 0;
            return;
        }

        if (CurrentForce >= RequiredForce)
        {
            The.EventManager.PullUp?.Invoke();

            CurrentForce = 0;
            //Расчёт новой RequiredForce
        }
    }

    public IEnumerator DecreaseForceCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(ReloadingDecreaseForce);
            ChangeCurrentForce(-1);
        }
    }
}
