using System;
using UnityEngine;
public class ContainerCounter : Counter 
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    public event EventHandler OnPlayerGrabbedObject;
    
    
    public override void  Interact(Player player)
    {
        if (player.KitchenObject != null)
        {
            Debug.Log("PLAYERIN ELİ DOLU");
            return;
        }

        var kitchenObjTransform = Instantiate(kitchenObjectSO.Prefab);
        kitchenObjTransform.GetComponent<KitchenObject>().KitchenObjectParent = player;
        
        OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
    }
   
    
    
}
