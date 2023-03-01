using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;

public class Main : MonoBehaviour
{
    [SerializeField] private MainPanel MainPanel;

    void Start()
    {
        PlayGamesPlatform.Activate();
        Social.localUser.Authenticate((bool success) => { });

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
