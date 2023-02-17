using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : Counter
{
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            if (player.KitchenObject.TryGetPlate(out PlateKitchenObject plate))
            {
                plate.DestroySelf();
            }
        }
        
    }
}
