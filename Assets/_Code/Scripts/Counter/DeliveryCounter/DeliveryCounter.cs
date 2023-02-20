using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : Counter
{
    [SerializeField] private OrderManager orderManager;
    public static DeliveryCounter Instance;

    private void Awake()
    {
        Instance = this;
    }

    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            if (player.KitchenObject.TryGetPlate(out PlateKitchenObject plate))
            {
                if (orderManager.TryDeliverOrder(plate))
                {
                    Debug.Log("ORDER SUCSESSFUL");
                    plate.DestroySelf();
                    player.ClearKitchenObject();
                    return;
                }
                
                plate.DestroySelf();
                player.ClearKitchenObject();
                Debug.Log("ORDER FAİLED");
                
            }
        }
        
    }
}
