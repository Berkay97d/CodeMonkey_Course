using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMP_Text deliveredOrderText;


    private void Start()
    {
        GameController.Instance.OnStateChanged += InstanceOnOnStateChanged;
    }
    
    private void InstanceOnOnStateChanged(object sender, EventArgs e)
    {
        if (GameController.Instance.IsGameOver())
        {
            Show();
            deliveredOrderText.text = OrderManager.Instance.SuccessOrderAmount.ToString();
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
