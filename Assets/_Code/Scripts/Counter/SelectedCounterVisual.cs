using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounterVisual : MonoBehaviour
{
    [SerializeField] private Counter counter;
    [SerializeField] private GameObject[] selectedCVisualObj;
    
    
    private void Start()
    {
        Player.Instance.OnSelectedCounterChanged += PlayerOnSelectedCounterChanged;
    }

    private void PlayerOnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
        if (e.SelectedCounter == counter)
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
        foreach (var selected in selectedCVisualObj)
        {
            selected.SetActive(true);
        }
    }

    private void Hide()
    {
        foreach (var selected in selectedCVisualObj)
        {
            selected.SetActive(false);
        }
    }
}
