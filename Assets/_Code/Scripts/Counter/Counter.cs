using UnityEditor;
using UnityEngine;

public class Counter : MonoBehaviour, IKitchenObjectParent
{
    public KitchenObject KitchenObject
    {
        get => kitchenObject;
        set => SetKitchenObject(value);
    }
    
    [SerializeField] private Transform counterTopPoint;
    
    private KitchenObject kitchenObject;


    public virtual void Interact(Player player)
    {
        Debug.LogError("BURAYA NASIL GİRDİN AMQ ?");
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
    
    private void SetKitchenObject(KitchenObject kObject)
    {
        kitchenObject = kObject;
    }

    private KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    
}
