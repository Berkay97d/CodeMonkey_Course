using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderManagerUI : MonoBehaviour
{
    [SerializeField] private Transform container;
    [SerializeField] private Transform template;
    [SerializeField] private OrderManager orderManager;
    [SerializeField] private Image imagePrefab;
    [SerializeField] private OrderItemSO[] possibleOrders;
    
    
    private void Awake()
    {
        template.gameObject.SetActive(false);
    }

    public IEnumerator UpdateVisual()
    {
        yield return new WaitForSeconds(0.01f);
        
        foreach (Transform child in container)
        {
            Destroy(child.gameObject);
        }
        
        foreach (var order in orderManager.orders)
        {
            var orderTransform = Instantiate(template, container);
            orderTransform.GetComponentInChildren<TMP_Text>().text = order.OrderName;
            orderTransform.gameObject.SetActive(true);

            foreach (var ingredient in order.Ingrediants)
            {
                var a = Instantiate(imagePrefab, orderTransform.Find("Background"));
                a.name = ingredient.ObjectName;
                a.sprite = ingredient.Sprite;
            }
        }
    }
    
}
