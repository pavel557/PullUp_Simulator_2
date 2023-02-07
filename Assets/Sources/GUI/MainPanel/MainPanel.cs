using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private TopPanel TopPanel;
    [SerializeField] private EnergyPanel EnergyPanel;
    [SerializeField] private BottomPanel BottomPanel;
    [SerializeField] private CounterPullup CounterPullup;
    [SerializeField] private Button MainButton;

    public void Init()
    {
        TopPanel.Init();
        EnergyPanel.Init();
        BottomPanel.Init();
        CounterPullup.Init();
        MainButton.interactable = false;
        The.EventManager.StartPullUp += () => { MainButton.interactable = true; };
        The.EventManager.EndPullUp += () => { MainButton.interactable = false; };
        MainButton.onClick.AddListener(OnMainButtonClick);
    }

    public void OnMainButtonClick()
    {
        The.GameSession.ChangeCurrentAmountEnergy(-1);
        The.PullupManager.ChangeCurrentForce(1);
    }
}
