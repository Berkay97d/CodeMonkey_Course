﻿using UnityEngine;

public class StoveCounter : Counter
{
    public override void Interact(Player player)
    {
        if (KitchenObject == null)
        {
            if (player.KitchenObject != null)
            {
                
                player.KitchenObject.KitchenObjectParent = this;
                Debug.Log("PUTTED");
                return;
            }

            Debug.Log("NOTHING TO PUT OR TAKE");
            return;
        }

        if (player.KitchenObject == null)
        {
            KitchenObject.KitchenObjectParent = player;
            
            Debug.Log("GRABBED");
            return;
        }

        Debug.Log("BOTH FULL");
    }
    
    
    
}


