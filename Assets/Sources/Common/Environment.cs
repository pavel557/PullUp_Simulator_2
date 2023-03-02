using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{
    [SerializeField] private List<GameObject> HorizontalBars;
    [SerializeField] private List<GameObject> Backgrounds;

    [SerializeField] private GameObject CurentHorizontalBars;
    [SerializeField] private GameObject CurentBackgrounds;

    private int CurentLevel;
    

    private void Start()
    {
        The.EventManager.EnvironmentChanged += ChangeEnvironment;
    }

    public void ChangeEnvironment(int level)
    {
        if (level != CurentLevel)
        {
            CurentHorizontalBars.SetActive(false);
            CurentBackgrounds.SetActive(false);
            CurentHorizontalBars = HorizontalBars[level];
            CurentBackgrounds= Backgrounds[level];
            CurentHorizontalBars.SetActive(true);
            CurentBackgrounds.SetActive(true);
        }
    }
}
