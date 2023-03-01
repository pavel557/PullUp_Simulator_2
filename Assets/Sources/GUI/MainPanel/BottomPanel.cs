using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomPanel : MonoBehaviour
{
    [SerializeField] private Button StartRepeatingButton;
    [SerializeField] private Button EndDayButton;
    [SerializeField] private Button ShopButton;
    [SerializeField] private Button HighScoreTableButton;

    public void Init()
    {
        StartRepeatingButton.interactable = true;
        EndDayButton.interactable = true;
        ShopButton.interactable = true;

        StartRepeatingButton.onClick.AddListener(OnStartRepeatingButtonClick);
        EndDayButton.onClick.AddListener(OnEndDayButtonClick);
        HighScoreTableButton.onClick.AddListener(OnHighScoreTableButton);
        ShopButton.onClick.AddListener(OnShopButtonClick);

        The.EventManager.EndPullUp += () => { StartRepeatingButton.interactable = true; };
        The.EventManager.EndPullUp += () => { EndDayButton.interactable = true; };
        The.EventManager.EndPullUp += () => { ShopButton.interactable = true; };
    }

    private void OnStartRepeatingButtonClick()
    {
        The.EventManager.StartPullUp?.Invoke();

        StartRepeatingButton.interactable = false;
        EndDayButton.interactable = false;
        ShopButton.interactable = false;
    }

    private void OnEndDayButtonClick()
    {
        var objPanel = Instantiate(Resources.Load<GameObject>("GUI/NextDayPanel"), transform.parent.parent);
        var nextDayPanel = objPanel.GetComponent<NextDayPanel>();
        nextDayPanel.Init();
    }

    private void OnShopButtonClick()
    {
        var objPanel = Instantiate(Resources.Load<GameObject>("GUI/ShopPanel"), transform.parent.parent);
        var shopPanel = objPanel.GetComponent<ShopPanel>();
        shopPanel.Init();
    }

    private void OnHighScoreTableButton()
    {
        Social.ShowLeaderboardUI();
    }
}
