using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;
    
    public void Interact()
    {
        if (kitchenObject == null)
        {
            var kitchenObjectTransform = Instantiate(kitchenObjectSO.Prefab, counterTopPoint);
            kitchenObjectTransform.localPosition = Vector3.zero;

            kitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            kitchenObject.ClearCounter = this;

            Debug.Log("Interacted with table and spawned a " + kitchenObjectSO.name);
        }
        else
        {
            Debug.Log( "DOLU" + kitchenObject.ClearCounter.name);
        }
    }
}
