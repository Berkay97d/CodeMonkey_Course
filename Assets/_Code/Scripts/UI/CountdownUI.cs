using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownUI : MonoBehaviour
{
    [SerializeField] private TMP_Text countdown;


    private void Start()
    {
        GameController.Instance.OnStateChanged += InstanceOnOnStateChanged;
    }


    private void Update()
    {
        countdown.text = GameController.Instance.GetCountdownTimer().ToString("F0");
    }

    private void InstanceOnOnStateChanged(object sender, EventArgs e)
    {
        if (GameController.Instance.IsCountdownActive())
        {
            Show();
            return;
        }
        
        Hide();
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
