using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SoundManager : MonoBehaviour
{

    public static SoundManager Instance;
    
    [SerializeField] private AudioClipRefsSO audioClipRefs;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OrderManager.OnOrderSuccess += OrderManagerOnOrderSuccess;
        OrderManager.OnOrderFail += OrderManagerOnOrderFail;
        
        CuttingCounter.OnAnyCut += CuttingCounterOnAnyCut;
        
        Player.Instance.OnPlayerPickSomething += PlayerOnPlayerPickSomething;
        Player.Instance.OnPlayerDropSomething += PlayerOnPlayerDropSomething;
        
        TrashCounter.OnObjectTrash += TrashCounterOnObjectTrash;
    }

    private void TrashCounterOnObjectTrash(object sender, EventArgs e)
    {
        var trash = sender as TrashCounter;
        PlaySound(audioClipRefs.trash, trash.transform.position);
    }

    private void PlayerOnPlayerDropSomething(object sender, EventArgs e)
    {
        PlaySound( audioClipRefs.objectDrop, Player.Instance.transform.position);
    }

    private void PlayerOnPlayerPickSomething(object sender, EventArgs e)
    {
        PlaySound( audioClipRefs.objectPickup, Player.Instance.transform.position);
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

    public void PlayPlayerStep()
    {
        PlaySound(audioClipRefs.footstep, Player.Instance.transform.position);
    }
    
    
    
}
