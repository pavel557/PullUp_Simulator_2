using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    [SerializeField] private TopPanel TopPanel;

    public void Init()
    {
        TopPanel.Init();
    }
}
