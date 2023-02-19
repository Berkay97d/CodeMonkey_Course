using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarUI : MonoBehaviour
{
    [SerializeField] private GameObject hasProgressGameObject;
    [SerializeField] private Image fillImage;
    [SerializeField] private Canvas canvas;

    private IHasProgress hasProgress;


    private void Start()
    {
        hasProgress = hasProgressGameObject.GetComponent<IHasProgress>();
        
        hasProgress.OnProgressChance += HasProgressOnOnProgressChance;
    }

    private void HasProgressOnOnProgressChance(object sender, IHasProgress.OnProgressChangedArguments e)
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
