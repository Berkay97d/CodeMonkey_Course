using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class OrderManager : MonoBehaviour
{
    public static event EventHandler OnOrderSuccess;
    public static event EventHandler OnOrderFail;
    public static OrderManager Instance { get; private set; }
    public int SuccessOrderAmount { get; private set; }
    
    
    [SerializeField] private OrderItemSO[] possibleOrders ;
    [SerializeField] private int maxOrderCount;
    [SerializeField] private OrderManagerUI orderManagerUI;
    

    private OrderItemSO CurrentOrder => orders[0];

    [HideInInspector] public List<OrderItemSO> orders = new List<OrderItemSO>();


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        OrderFood(maxOrderCount);
    }

    private void OrderFood(int orderNumber)
    {
        for (int i = 0; i < orderNumber; i++)
        {
            var orderr = GetRandomOrder();
            orders.Add(orderr);
        }
        StartCoroutine(orderManagerUI.UpdateVisual());
    }

    private OrderItemSO GetRandomOrder()
    {
        var randomNum = Random.Range(0, possibleOrders.Length);
        return possibleOrders[randomNum];
    }

    public bool TryDeliverOrder(PlateKitchenObject plateKitchenObject)
    {
        if (plateKitchenObject.NumOfKitchenObjectOnPlate() != CurrentOrder.Ingrediants.Length)
        {
            OnOrderFail?.Invoke(this, EventArgs.Empty);
            return false;
        }
        
        var numOfIngredientInOrder = CurrentOrder.Ingrediants.Length;
        var matchNumber = 0;
        
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
            OrderFood(1);
            OnOrderSuccess?.Invoke(this, EventArgs.Empty);
            SuccessOrderAmount++;
            return true;
        }
        
        OnOrderFail?.Invoke(this, EventArgs.Empty);
        return false;
        
    }
}
