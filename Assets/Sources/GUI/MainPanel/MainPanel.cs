using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private TopPanel TopPanel;
    [SerializeField] private EnergyPanel EnergyPanel;
    [SerializeField] private Button MainButton;

    public void Init()
    {
        TopPanel.Init();
        EnergyPanel.Init();
        MainButton.gameObject.SetActive(true);
        MainButton.onClick.AddListener(OnMainPanelClick);
    }

    public void OnMainPanelClick()
    {
        The.GameSession.ChangeCurrentAmountEnergy(-1);
    }
}
