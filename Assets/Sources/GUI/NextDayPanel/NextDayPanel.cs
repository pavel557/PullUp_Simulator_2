using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextDayPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text TopText;
    [SerializeField] private Button NextDayButton;
    [SerializeField] private Button BackButton;

    public void Init()
    {
        TopText.text = "Если вы завершите день сейчас, вы получите:" +
                        "\n" + "+" + The.PullupManager.SumPullups + " энергии" +
                        "\n" + "-" + The.GameSession.CalculateFatigueChange() + " усталости";

        NextDayButton.onClick.AddListener(() => { The.GameSession.ChangeDay(); Destroy(this.gameObject); });
        BackButton.onClick.AddListener(() => Destroy(this.gameObject));
    }
}
