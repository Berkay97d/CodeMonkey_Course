using System;
using UnityEngine;

public class StoveCounter : Counter, IHasProgress
{
    public event EventHandler<IHasProgress.OnProgressChangedArguments> OnProgressChance;
    public event EventHandler<OnFryStateChangedEventArg> OnFryStateChanged;
    public class OnFryStateChangedEventArg : EventArgs
    {
        public bool isFrying;
    }
    
    [SerializeField] private FryingRecipeSO[] fryingRecipeSos;
    [SerializeField] private ProgressBarUI progressBar;
    

    private float fryingTime;

    private void Update()
    {
        HandleCooking();
    }

    private void HandleCooking()
    {
        if (HasKitchenObject())
        {
            fryingTime += Time.deltaTime;

            var fryingRecipe = GetFryingRecipeSO(KitchenObject.GetKitchenObjectSO());
            

            if (GetOutputForInput(KitchenObject.GetKitchenObjectSO()) == null)
            {
                Debug.Log("No Output of burned meets");
                
                progressBar.Hide();
                
                OnFryStateChanged?.Invoke(this, new OnFryStateChangedEventArg()
                {
                    isFrying = false
                });
                
                return;
            }
            
            OnProgressChance?.Invoke(this, new IHasProgress.OnProgressChangedArguments
            {
                progressNormalized = fryingTime / fryingRecipe.FryingTimerMax 
            });
            
            progressBar.Show();
            
            OnFryStateChanged?.Invoke(this, new OnFryStateChangedEventArg()
            {
                isFrying = true
            });

            if (fryingRecipe.FryingTimerMax <= fryingTime)
            {
                KitchenObject.DestroySelf();
                fryingTime = 0f;
                KitchenObject.SpawnKitchenObject(fryingRecipe.Output, this);
            }
        }

        else
        {
            OnFryStateChanged?.Invoke(this, new OnFryStateChangedEventArg()
            {
                isFrying = false
            });
            
            progressBar.Hide();
        }
    }

    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.KitchenObject != null)
            {
                if (HasRecipeWithOutput(player.KitchenObject.GetKitchenObjectSO()))
                {
                    player.KitchenObject.KitchenObjectParent = this;
                    player.ClearKitchenObject();
                    Debug.Log("PUTTED");
                    return;
                }

                Debug.Log("YOU PUT SOMETHING CAN NOT BE FRYED");
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
                    }
                }
            }
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
        
        if (!player.HasKitchenObject())
        {
            KitchenObject.KitchenObjectParent = player;
            
            Debug.Log("GRABBED");
            return;
        }

        Debug.Log("BOTH FULL");
    }
    
    private bool HasRecipeWithOutput(KitchenObjectSO kitchenObjectSO)
    {
        var fryingRecipe = GetFryingRecipeSO(kitchenObjectSO);
        return fryingRecipe != null;
    }
    
    private KitchenObjectSO GetOutputForInput(KitchenObjectSO kitchenObjectSO)
    {
        var fryingRecipe = GetFryingRecipeSO(kitchenObjectSO);

        if (fryingRecipe != null)
        {
            return fryingRecipe.Output;
        }

        return null;
    }

    private FryingRecipeSO GetFryingRecipeSO(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (var fryingRecipe in fryingRecipeSos)
        {
            if (fryingRecipe.Input == inputKitchenObjectSO )
            {
                return fryingRecipe;
            }
        }

        return null;
    }
    
}


