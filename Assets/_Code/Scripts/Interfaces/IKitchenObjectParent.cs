using UnityEngine;

public interface IKitchenObjectParent
{
    public KitchenObject KitchenObject { get; set; }
    
    public Transform GetKitchenObjectCarryTransform();
    
    public void ClearKitchenObject();

    public bool HasKitchenObject();


}
