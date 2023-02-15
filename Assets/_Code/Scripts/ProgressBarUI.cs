using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private CuttingCounter cuttingCounter;
    [SerializeField] private Image fillImage;
    [SerializeField] private Canvas canvas;
    


    private void Start()
    {
        cuttingCounter.OnProgressChance += CuttingCounterOnOnProgressChance;
    }

    private void CuttingCounterOnOnProgressChance(object sender, CuttingCounter.OnProgressChangedArguments e)
    {
        fillImage.fillAmount = e.progressNormalized;
    }

    public void Show()
    {
        canvas.gameObject.SetActive(true);
    }

    public void Hide()
    {
        canvas.gameObject.SetActive(false);
    }
}
