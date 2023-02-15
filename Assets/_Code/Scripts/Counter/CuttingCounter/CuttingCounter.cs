using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : Counter
{
    public class OnProgressChangedArguments : EventArgs
    {
        public float progressNormalized;
    }
    public event EventHandler<OnProgressChangedArguments> OnProgressChance;
    public event EventHandler OnPlayerCutObject;

    [SerializeField] private KitchenObjectRecipeSO[] kitchenObjectRecipes;
    [SerializeField] private ProgressBarUI progressBar;

    private int currentCuttingCount;
    
    
    public override void Interact(Player player)
    {
        if (KitchenObject == null)
        {
            if (player.KitchenObject != null)
            {
                currentCuttingCount = 0;
                
                player.KitchenObject.KitchenObjectParent = this;
                
                progressBar.Show();
                
                
                if (!IsKitchenObjectCuttable())
                {
                    RaiseProgressChangedEvent(0f);
                    return;
                }
                
                RaiseProgressChangedEvent((float) currentCuttingCount / GetRecipeSO(KitchenObject.GetKitchenObjectSO()).CuttingCount);
                
                Debug.Log("PUTTED");
                return;
            }

            Debug.Log("NOTHING TO PUT OR TAKE");
            return;
        }

        if (player.KitchenObject == null)
        {
            KitchenObject.KitchenObjectParent = player;
            
            progressBar.Hide();
            Debug.Log("GRABBED");
            return;
        }

        Debug.Log("BOTH FULL");
        
    }
    
    public override void InteractSecondary(Player player)
    {
        if (HasKitchenObject() && !player.HasKitchenObject())
        {
            if (!IsKitchenObjectCuttable()) return;
            
            currentCuttingCount++;
            
            var product = GetOutput(KitchenObject.GetKitchenObjectSO());
            RaiseProgressChangedEvent((float) currentCuttingCount / GetRecipeSO(KitchenObject.GetKitchenObjectSO()).CuttingCount);

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

    private void RaiseProgressChangedEvent(float progress)
    {
        OnProgressChance?.Invoke(this, new OnProgressChangedArguments
        {
            progressNormalized = progress
        });
    }

    private bool IsKitchenObjectCuttable()
    {
        return GetOutput(KitchenObject.GetKitchenObjectSO()) != null;
    }
}

    

