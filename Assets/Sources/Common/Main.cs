using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    [SerializeField] private MainPanel MainPanel;

    void Start()
    {
        The.ConfigManager.Init();
        The.SaveManager.LoadGame();
        MainPanel.Init();
        The.PullupManager.Init();
    }

    private void OnApplicationFocus(bool focus)
    {
        if (focus == false)
            The.SaveManager.SaveGame();
    }

    private void OnApplicationQuit()
    {
        The.SaveManager.SaveGame();
    }
}
