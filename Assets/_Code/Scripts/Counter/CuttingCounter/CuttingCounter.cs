using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : Counter
{
    public event EventHandler OnPlayerCutObject;

    [SerializeField] private KitchenObjectRecipeSO[] kitchenObjectRecipes;
    
    private int currentCuttingCount;
    
    
    public override void Interact(Player player)
    {
        if (KitchenObject == null)
        {
            if (player.KitchenObject != null)
            {
                currentCuttingCount = 0;
                
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
            currentCuttingCount++;
            var product = GetOutput(KitchenObject.GetKitchenObjectSO());

            if (product == null) return;
            
            if (currentCuttingCount >= GetRecipeSO(KitchenObject.GetKitchenObjectSO()).CuttingCount )
            {
                KitchenObject.DestroySelf(); 
                KitchenObject.SpawnKitchenObject(product, this);
            }

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

    private KitchenObjectRecipeSO GetRecipeSO(KitchenObjectSO kitchenObjectSO)
    {
        foreach (var kitchenObjectRecipe in kitchenObjectRecipes)
        {
            if (kitchenObjectRecipe.Input == kitchenObjectSO)
            {
                return kitchenObjectRecipe;
            }
        }

        return null;
    }
    
    
}

    

