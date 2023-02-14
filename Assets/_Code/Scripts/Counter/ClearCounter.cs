using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;

    public KitchenObject KitchenObject
    {
        get => kitchenObject;
        set => SetKitchenObject(value);
    }
    

    public void Interact(Player player)
    {
        if (player.KitchenObject != null)
        {
            player.KitchenObject.KitchenObjectParent = this;
            Debug.Log("PLAYERIN ELİ DOLU");
            return;
        }
        
        if (kitchenObject == null)
        {
            var kitchenObjectTransform = Instantiate(kitchenObjectSO.Prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().KitchenObjectParent = this;
            
            Debug.Log("Interacted with " + name +  " and spawned a " + kitchenObjectSO.name);
        }
        else
        {
            Debug.Log("Kitchen object " + kitchenObjectSO.name + " gived to Player");
            kitchenObject.KitchenObjectParent = player;
        }
    }

    public Transform GetKitchenObjectCarryTransform()
    {
        return counterTopPoint;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
    
    private void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    private KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
}
