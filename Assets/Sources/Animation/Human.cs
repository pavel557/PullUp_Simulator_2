using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour
{
    [SerializeField] private Animator HumanAnimator;

    private int IDStartPullUp;
    private int IDPullUp;
    private int IDEndPullUp;

    private void Start()
    {
        IDStartPullUp = Animator.StringToHash("StartPullUp");
        IDPullUp = Animator.StringToHash("PullUp");
        IDEndPullUp = Animator.StringToHash("EndPullUp");

        The.EventManager.StartPullUp += StartPullUp;
        The.EventManager.PullUp += PullUp;
        The.EventManager.EndPullUp += EndPullUp;
    }

    public void StartPullUp()
    {
        ResetTriggers();
        HumanAnimator.SetTrigger(IDStartPullUp);
        StartCoroutine(The.PullupManager.DecreaseForceCoroutine());
    }

    public void PullUp()
    {
        //ResetTriggers();
        HumanAnimator.SetTrigger(IDPullUp);
    }

    public void EndPullUp()
    {
        ResetTriggers();
        HumanAnimator.SetTrigger(IDEndPullUp);
        StopCoroutine(The.PullupManager.DecreaseForceCoroutine());
    }

    private void ResetTriggers()
    {
        HumanAnimator.ResetTrigger(IDStartPullUp);
        HumanAnimator.ResetTrigger(IDPullUp);
        HumanAnimator.ResetTrigger(IDEndPullUp);
    }
}
