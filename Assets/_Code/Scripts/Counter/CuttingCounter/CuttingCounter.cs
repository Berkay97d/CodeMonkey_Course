using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : Counter, IHasProgress
{
    
    public event EventHandler<IHasProgress.OnProgressChangedArguments> OnProgressChance;
    public event EventHandler OnPlayerCutObject;

    [SerializeField] private KitchenObjectRecipeSO[] kitchenObjectRecipes;
    [SerializeField] private ProgressBarUI progressBar;

    private int currentCuttingCount;
    
    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.KitchenObject != null)
            {
                currentCuttingCount = 0;
                
                player.KitchenObject.KitchenObjectParent = this;
                
                if (!IsKitchenObjectCuttable())
                {
                    RaiseProgressChangedEvent(0f);
                    return;
                }
                
                progressBar.Show();
                
                RaiseProgressChangedEvent((float) currentCuttingCount / GetRecipeSO(KitchenObject.GetKitchenObjectSO()).CuttingCount);
                
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
                if (player.KitchenObject.TryGetPlate(out PlateKitchenObject plate))
                {
                    if (plate.TryAddIngredient(KitchenObject.GetKitchenObjectSO()))
                    {
                        KitchenObject.DestroySelf();
                        
                        progressBar.Hide();
                        
                        return;
                    }
                }
            }
        }

        if (!player.HasKitchenObject())
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
        OnProgressChance?.Invoke(this, new IHasProgress.OnProgressChangedArguments
        {
            progressNormalized = progress
        });
    }

    private bool IsKitchenObjectCuttable()
    {
        return GetOutput(KitchenObject.GetKitchenObjectSO()) != null;
    }
}

    

