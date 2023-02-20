using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePauseUI : MonoBehaviour
{
    private bool isPaused = false;

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
