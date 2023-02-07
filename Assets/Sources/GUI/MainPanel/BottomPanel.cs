using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomPanel : MonoBehaviour
{
    [SerializeField] private Button StartRepeatingButton;
    [SerializeField] private Button EndDayButton;


    public void Init()
    {
        StartRepeatingButton.interactable = true;
        EndDayButton.interactable = true;

        StartRepeatingButton.onClick.AddListener(OnStartRepeatingButtonClick);
        EndDayButton.onClick.AddListener(OnEndDayButtonClick);

        //јктивировать кнопку, когда подт€шивание завершено
        The.EventManager.EndPullUp += () => { StartRepeatingButton.interactable = true; };
        The.EventManager.EndPullUp += () => { EndDayButton.interactable = true; };
    }

    private void OnStartRepeatingButtonClick()
    {
        The.EventManager.StartPullUp?.Invoke();

        StartRepeatingButton.interactable = false;
        EndDayButton.interactable = false;
    }

    private void OnEndDayButtonClick()
    {
        The.GameSession.ChangeDay();

        The.GameSession.ChangeMaxAmountEnergy(1);
    }
}
