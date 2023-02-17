using System.Collections.Generic;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{

    [SerializeField] private List<KitchenObjectSO> validKitchenObjects;
    
    
    private List<KitchenObjectSO> kitchenObjectSoList = new List<KitchenObjectSO>();

    
    
    
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (kitchenObjectSoList.Contains(kitchenObjectSO)) return false;

        if (!validKitchenObjects.Contains(kitchenObjectSO)) return false;

        kitchenObjectSoList.Add(kitchenObjectSO);
        return true;
    }
    
    
    
}
