using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private MainPanel MainPanel;

    void Start()
    {
        The.GameSession.Init();
        MainPanel.Init();
    }

    //void Update()
    //{
        
    //}
}
