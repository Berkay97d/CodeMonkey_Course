using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMP_Text deliveredOrderText;
    [SerializeField] private Button mainMenuButton;
    

    private void Awake()
    {
        mainMenuButton.onClick.AddListener(() =>
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
        });
    }

    private void Start()
    {
        GameController.Instance.OnStateChanged += InstanceOnOnStateChanged;
        Hide();
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
