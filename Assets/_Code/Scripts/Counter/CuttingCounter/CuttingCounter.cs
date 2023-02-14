using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : Counter
{
    public event EventHandler OnPlayerCutObject;

    [SerializeField] private KitchenObjectRecipeSO[] kitchenObjectRecipes;
    
    
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
    
    public override void InteractSecondary(Player player)
    {
        if (HasKitchenObject() && !player.HasKitchenObject())
        {
            var product = GetOutput(KitchenObject.GetKitchenObjectSO());

            if (product == null) return;
            
            KitchenObject.DestroySelf(); 
            KitchenObject.SpawnKitchenObject(product, this);
            OnPlayerCutObject?.Invoke(this, EventArgs.Empty);

        }
    }

    private KitchenObjectSO GetOutput(KitchenObjectSO kitchenObjectSO)
    {
        foreach (var kitchenObjectRecipe in kitchenObjectRecipes)
        {
            if (kitchenObjectRecipe.Input == kitchenObjectSO)
            {
                return kitchenObjectRecipe.Output;
            }
        }

        return null;
    }
    
    
}

    

