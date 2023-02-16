using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveCounterVisual : MonoBehaviour
{
    [SerializeField] private GameObject[] fryingEffects;
    [SerializeField] private StoveCounter stoveCounter;


    private void Start()
    {
        stoveCounter.OnFryStateChanged += StoveCounterOnOnFryStateChanged;
    }

    private void StoveCounterOnOnFryStateChanged(object sender, StoveCounter.OnFryStateChangedEventArg e)
    {
        if (e.isFrying)
        {
            FryEffectsOn();
        }
        else
        {
            FryEffectsOff();
        }
    }


    private void FryEffectsOn()
    {
        foreach (var frying in fryingEffects)
        {
            frying.SetActive(true);   
        }
    }

    private void FryEffectsOff()
    {
        foreach (var frying in fryingEffects)
        {
            frying.SetActive(false);
        }
    }
    
}
