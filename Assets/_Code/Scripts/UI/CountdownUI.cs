using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountdownUI : MonoBehaviour
{
    [SerializeField] private TMP_Text countdown;
    [SerializeField] private Animator animator;
    
    private int prev;

    private void Start()
    {
        GameController.Instance.OnStateChanged += InstanceOnOnStateChanged;
    }


    private void Update()
    {
        int count = Mathf.CeilToInt(GameController.Instance.GetCountdownTimer());
        countdown.text = count.ToString("F0");
        
        if(prev != count)
        {
            prev = count;
            animator.SetTrigger("Pop");
            SoundManager.Instance.PlayCountdownSound();
        }
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
