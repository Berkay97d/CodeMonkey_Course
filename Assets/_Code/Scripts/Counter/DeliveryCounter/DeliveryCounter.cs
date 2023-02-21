using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : Counter
{
    public static DeliveryCounter Instance;
    public event EventHandler OnDeliverySuccess;
    public event EventHandler OnDeliveryFail;
    
    [SerializeField] private OrderManager orderManager;
    
    
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
                    
                    OnDeliverySuccess?.Invoke(this, EventArgs.Empty);
                    
                    plate.DestroySelf();
                    player.ClearKitchenObject();
                    return;
                }
                
                OnDeliveryFail?.Invoke(this, EventArgs.Empty);
                
                plate.DestroySelf();
                player.ClearKitchenObject();
                Debug.Log("ORDER FAİLED");
                
            }
        }
        
    }
}
