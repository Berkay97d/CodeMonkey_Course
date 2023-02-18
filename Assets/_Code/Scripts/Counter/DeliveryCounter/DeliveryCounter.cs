using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : Counter
{
    [SerializeField] private OrderManager orderManager;
    
    
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
                    return;
                }
                
                plate.DestroySelf();
                Debug.Log("ORDER FAİLED");
                
            }
        }
        
    }
}
