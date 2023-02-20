using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : Counter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                
                player.KitchenObject.KitchenObjectParent = this;
                player.ClearKitchenObject();
                Debug.Log("PUTTED");
                return;
            }

            Debug.Log("NOTHING TO PUT OR TAKE");
            return;
        }

        if (HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (KitchenObject.TryGetPlate(out PlateKitchenObject plate))
                {
                    if (plate.TryAddIngredient(player.KitchenObject.GetKitchenObjectSO()))
                    {
                        player.KitchenObject.DestroySelf();
                        player.ClearKitchenObject();
                        return;
                    }
                }
            }
        }
        
        if (player.HasKitchenObject())
        {
            if (player.KitchenObject.TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                if (plateKitchenObject.TryAddIngredient(KitchenObject.GetKitchenObjectSO()))
                {
                    KitchenObject.DestroySelf();
                }
                return;
            }
        }
        

        if (!player.HasKitchenObject())
        {
            KitchenObject.KitchenObjectParent = player;
            Debug.Log("GRABBED");
            return;
        }

        Debug.Log("BOTH FULL");
        
    }

    
}
