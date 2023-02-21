using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSituationUI : MonoBehaviour
{
    [SerializeField] private GameObject success;
    [SerializeField] private GameObject fail;
    [SerializeField] private float lifeTime;
    private float time;
    
    
    private void Start()
    {
        DeliveryCounter.Instance.OnDeliverySuccess += InstanceOnOnDeliverySuccess;
        DeliveryCounter.Instance.OnDeliveryFail += InstanceOnOnDeliveryFail;
    }

    private void Update()
    {
        if (success.activeSelf)
        {
            time += Time.deltaTime;
            if (time > lifeTime)
            {
                success.SetActive(false);
                time = 0;
            }
        }
        else if (fail.activeSelf)
        {
            time += Time.deltaTime;
            if (time > lifeTime)
            {
                fail.SetActive(false);
                time = 0;
            }
        }
    }

    private void InstanceOnOnDeliveryFail(object sender, EventArgs e)
    {
        fail.SetActive(true);
    }

    private void InstanceOnOnDeliverySuccess(object sender, EventArgs e)
    {
        success.SetActive(true);
    }
}
