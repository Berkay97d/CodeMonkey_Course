using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClipRefsSO audioClipRefs;
    
    
    private void Start()
    {
        OrderManager.OnOrderSuccess += OrderManagerOnOrderSuccess;
        OrderManager.OnOrderFail += OrderManagerOnOrderFail;
        
        CuttingCounter.OnAnyCut += CuttingCounterOnAnyCut;
    }

    private void CuttingCounterOnAnyCut(object sender, EventArgs e)
    {
        var counter = sender as CuttingCounter;
        PlaySound(audioClipRefs.chop, counter.transform.position);
    }

    private void OrderManagerOnOrderFail(object sender, EventArgs e)
    {
        PlaySound(audioClipRefs.deliveryFail, DeliveryCounter.Instance.transform.position);
    }

    private void OrderManagerOnOrderSuccess(object sender, EventArgs e)
    {
        PlaySound(audioClipRefs.deliverySuccess, DeliveryCounter.Instance.transform.position);
    }

    private void PlaySound(AudioClip[] audioClip, Vector3 position, float volume = 1f)
    {
        PlaySound(audioClip[Random.Range(0, audioClip.Length)], position, volume);
    }
    
    private void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1f)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
    
    
    
}
