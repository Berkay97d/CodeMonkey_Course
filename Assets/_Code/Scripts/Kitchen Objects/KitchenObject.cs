using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    public ClearCounter ClearCounter 
    {
        get => clearCounter;
        set => SetClearCounter(value);
    }
    
    private ClearCounter clearCounter;

    
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    private ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
    
    private void SetClearCounter(ClearCounter cCounter)
    {
        if (cCounter.HasKitchenObject())
        {
            Debug.Log("this clear counter already has kitchen object");
        }
        
        if (clearCounter != null)
        {
            clearCounter.ClearKitchenObject();
        }
        
        clearCounter = cCounter;

        cCounter.KitchenObject = this;
        
        transform.parent = cCounter.GetCounterTopPoint();
        transform.localPosition = Vector3.zero;
    }
    
    
    
}
