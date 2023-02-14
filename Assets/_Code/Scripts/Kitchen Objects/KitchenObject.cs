using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    
    public IKitchenObjectParent KitchenObjectParent 
    {
        get => kitchenObjectParent;
        set => SetKitchenObjectParent(value);
    }
    
    private IKitchenObjectParent kitchenObjectParent;
    
    
    
    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    private IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }
    
    private void SetKitchenObjectParent(IKitchenObjectParent kObjectParent)
    {
        if (kObjectParent.HasKitchenObject())
        {
            Debug.Log("this clear counter already has kitchen object");
            return;
        }
        
        if (this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        
        this.kitchenObjectParent = kObjectParent;

        kObjectParent.KitchenObject = this;
        
        transform.parent = kObjectParent.GetKitchenObjectCarryTransform();
        transform.localPosition = Vector3.zero;
    }
    
    
    
}
