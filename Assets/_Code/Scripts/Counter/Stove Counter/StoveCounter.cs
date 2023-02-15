using UnityEngine;

public class StoveCounter : Counter
{
    [SerializeField] private FryingRecipeSO[] fryingRecipeSos;
    
    
    public override void Interact(Player player)
    {
        if (KitchenObject == null)
        {
            if (player.KitchenObject != null)
            {
                if (HasRecipeWithOutput(player.KitchenObject.GetKitchenObjectSO()))
                {
                    player.KitchenObject.KitchenObjectParent = this;
                    Debug.Log("PUTTED");
                    return;
                }

                Debug.Log("YOU PUT SOMETHING CAN NOT BE FRYED");
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


