using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class OrderManager : MonoBehaviour
{
    [SerializeField] private OrderItemSO[] possibleOrders ;
    [SerializeField] private int maxOrderCount;
    
    
    private List<OrderItemSO> orders = new List<OrderItemSO>();


    private void Start()
    {
        while (orders.Count != maxOrderCount)
        {
            OrderFood();
        }
    }

    private void OrderFood()
    {
        if (orders.Count >= maxOrderCount)
        {
            return;
        }
        
        var orderr = GetRandomOrder();
        orders.Add(orderr);
        Debug.Log("I ORDERED A " + orderr.OrderName);
    }

    private OrderItemSO GetRandomOrder()
    {
        var randomNum = Random.Range(0, possibleOrders.Length);
        return possibleOrders[randomNum];
    }
}
