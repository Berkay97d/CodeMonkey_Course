using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private Button mainMenuButton;
    
    private bool isPaused = false;


    private void Awake()
    {
        mainMenuButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(0);
        });
    }

    private void Start()
    {
        GameInput.Instance.OnPause += InstanceOnOnPause;
        Hide();
    }

    private void InstanceOnOnPause(object sender, EventArgs e)
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Show();
        }
        else
        {
            Hide();
        }
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
