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

    private void SetClearCounter(ClearCounter clearCounter)
    {
        this.clearCounter = clearCounter;
    }
    
}
