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
            TryPutKitchenObjectBack(player, kitchenObjectSO);
            return;
        }

        KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);
        
        OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
    }

    private void TryPutKitchenObjectBack(Player player, KitchenObjectSO container)
    {
        if (player.KitchenObject.GetKitchenObjectSO() == container)
        {
            player.KitchenObject.DestroySelf();
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
    }
    
}
