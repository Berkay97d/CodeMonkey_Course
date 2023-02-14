using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : Counter
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    
    public override void Interact(Player player)
    {
        if (player.KitchenObject != null)
        {
            player.KitchenObject.KitchenObjectParent = this;
            Debug.Log("PLAYERIN ELİ DOLU");
            return;
        }
        
        if (KitchenObject == null)
        {
            var kitchenObjectTransform = Instantiate(kitchenObjectSO.Prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().KitchenObjectParent = this;
            
            Debug.Log("Interacted with " + name +  " and spawned a " + kitchenObjectSO.name);
        }
        else
        {
            Debug.Log("Kitchen object " + kitchenObjectSO.name + " gived to Player");
            KitchenObject.KitchenObjectParent = player;
        }
    }

    
}
