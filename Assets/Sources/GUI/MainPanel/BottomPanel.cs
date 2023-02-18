using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomPanel : MonoBehaviour
{
    [SerializeField] private Button StartRepeatingButton;
    [SerializeField] private Button EndDayButton;
    [SerializeField] private Button HighScoreTableButton;


    public void Init()
    {
        StartRepeatingButton.interactable = true;
        EndDayButton.interactable = true;

        StartRepeatingButton.onClick.AddListener(OnStartRepeatingButtonClick);
        EndDayButton.onClick.AddListener(OnEndDayButtonClick);
        HighScoreTableButton.onClick.AddListener(OnHighScoreTableButton);

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
        var objPanel = Instantiate(Resources.Load<GameObject>("GUI/NextDayPanel"), transform.parent.parent);
        var nextDayPanel = objPanel.GetComponent<NextDayPanel>();
        nextDayPanel.Init();
    }

    private void OnHighScoreTableButton()
    {
        Social.ShowLeaderboardUI();
    }
}
