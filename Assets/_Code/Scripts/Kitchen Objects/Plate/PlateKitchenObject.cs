using System;
using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public class OnIngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectSO AddedSO;
    }
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;

    [SerializeField] private List<KitchenObjectSO> validKitchenObjects;
    
    private List<KitchenObjectSO> kitchenObjectSoList = new List<KitchenObjectSO>();

    
    
    
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (kitchenObjectSoList.Contains(kitchenObjectSO)) return false;

        if (!validKitchenObjects.Contains(kitchenObjectSO)) return false;

        kitchenObjectSoList.Add(kitchenObjectSO);
        
        OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs
        {
            AddedSO = kitchenObjectSO
        });
        return true;
    }
    
    
    
}
