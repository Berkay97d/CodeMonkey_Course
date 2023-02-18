using System;
using System.Collections;
using System.Collections.Generic;
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

    private void UpdateVisual()
    {
        foreach (Transform chield in container)
        {
            if (chield == template) continue;
            
            Destroy(chield.gameObject);

            foreach (var order in orderManager)
            {
                var orderTransform = Instantiate(template, container);
                orderTransform.gameObject.SetActive(true);
            }
            
        }
    }
}
