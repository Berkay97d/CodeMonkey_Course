using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class OrderManager : MonoBehaviour
{
    [SerializeField] private OrderItemSO[] possibleOrders ;
    [SerializeField] private int maxOrderCount;

    public OrderItemSO CurrentOrder => orders[0];

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
        Debug.Log("I ORDERED A " + orderr.OrderName + " " + Time.time);
    }

    private OrderItemSO GetRandomOrder()
    {
        var randomNum = Random.Range(0, possibleOrders.Length);
        return possibleOrders[randomNum];
    }

    public bool TryDeliverOrder(PlateKitchenObject plateKitchenObject)
    {
        int numOfIngredientInOrder = CurrentOrder.Ingrediants.Length;
        int matchNumber = 0;
        
        foreach (var ingredientInPlate in plateKitchenObject)
        {
            foreach (var ingredientOrdered in CurrentOrder.Ingrediants)
            {
                if (ingredientOrdered == ingredientInPlate)
                {
                    matchNumber++;
                    break;
                }        
            }
        }


        if (matchNumber == numOfIngredientInOrder)
        {
            orders.Remove(CurrentOrder);
            OrderFood();
            return true;
        }
        return false;
    }
}
