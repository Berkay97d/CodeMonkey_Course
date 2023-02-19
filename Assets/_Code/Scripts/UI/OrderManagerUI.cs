using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderManagerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform template;
    [SerializeField] private OrderManager orderManager;
    
    
    private void Awake()
    {
        template.gameObject.SetActive(false);
    }

    public void UpdateVisual()
    {
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
        
        foreach (var order in orderManager.orders)
        {
            var orderTransform = Instantiate(template, container);
            orderTransform.GetComponentInChildren<TMP_Text>().text = order.OrderName;
            orderTransform.gameObject.SetActive(true);
        }
    }
}
