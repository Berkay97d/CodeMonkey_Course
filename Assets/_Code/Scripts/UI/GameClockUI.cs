using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClockUI : MonoBehaviour
{
    [SerializeField] private Image fillImage;
    
    private Color startColor = Color.green;
    private Color endColor = Color.red;

    private void Update()
    {
        if (GameController.Instance.IsGamePlaying())
        {
            fillImage.fillAmount = GameController.Instance.GetGameClockNormalized();
            fillImage.color = Color.Lerp(startColor, endColor, GameController.Instance.GetGameClockNormalized());
        }
        else
        {
            fillImage.fillAmount = 0f;
        }
    }
}
