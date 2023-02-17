using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    public IKitchenObjectParent KitchenObjectParent 
    {
        get => kitchenObjectParent;
        set => SetKitchenObjectParent(value);
    }
    
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

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
            Debug.Log("this object already has kitchen object");
            return;
        }

        kitchenObjectParent?.ClearKitchenObject();

        kitchenObjectParent = kObjectParent;

        kObjectParent.KitchenObject = this;
        
        transform.parent = kObjectParent.GetKitchenObjectCarryTransform();
        transform.localPosition = Vector3.zero;
    }

    public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenObject();
        
        Destroy(gameObject);
    }

    public static KitchenObject SpawnKitchenObject(KitchenObjectSO kitchenObjectSO, IKitchenObjectParent ikitchenObjectParent)
    {
        var obj = Instantiate(kitchenObjectSO.Prefab);
        var kitchenObj = obj.GetComponent<KitchenObject>();
        kitchenObj.KitchenObjectParent = ikitchenObjectParent;

        return kitchenObj;
    }

    public bool TryGetPlate(out PlateKitchenObject plateKitchenObject)
    {
        if (this is PlateKitchenObject)
        {
            plateKitchenObject = this as PlateKitchenObject;
            return true;
        }
        
        plateKitchenObject = null;
        return false;
    }
    
    
    
}
