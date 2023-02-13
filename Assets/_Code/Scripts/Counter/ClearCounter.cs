using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;

    public KitchenObject KitchenObject
    {
        get => kitchenObject;
        set => SetKitchenObject(value);
    }
    
    
    
    [SerializeField] private bool testing;
    [SerializeField] private ClearCounter secondCounter;
    

    private void Update()
    {
        if (testing && Input.GetKeyDown(KeyCode.T))
        {
            if (kitchenObject != null)
            {
                kitchenObject.ClearCounter = secondCounter;
            }
        }
    }

    public void Interact()
    {
        if (kitchenObject == null)
        {
            var kitchenObjectTransform = Instantiate(kitchenObjectSO.Prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().ClearCounter = this;
            
            Debug.Log("Interacted with table and spawned a " + kitchenObjectSO.name);
        }
        else
        {
            Debug.Log( "DOLU" + kitchenObject.ClearCounter.name);
        }
    }

    public Transform GetCounterTopPoint()
    {
        return counterTopPoint;
    }

    private void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    private KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
