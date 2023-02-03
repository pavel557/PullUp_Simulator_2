using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottomPanel : MonoBehaviour
{
    [SerializeField] private Button StartRepeatingButton;

    public void Init()
    {
        StartRepeatingButton.interactable = true;

        StartRepeatingButton.onClick.AddListener(OnStartRepeatingButtonClick);
    }

    private void OnStartRepeatingButtonClick()
    {
        The.EventManager.StartPullUp?.Invoke();

        StartRepeatingButton.interactable = false;
    }
}
