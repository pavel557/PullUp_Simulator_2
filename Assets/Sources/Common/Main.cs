using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private MainPanel MainPanel;

    void Start()
    {
        The.ConfigManager.Init();
        The.GameSession.Init();
        MainPanel.Init();
        The.PullupManager.Init();
    }

    //void Update()
    //{
        
    //}
}
