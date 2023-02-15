using System;
using UnityEngine;

public class TrashCounter : Counter
{
    public event EventHandler OnPlayerInteractWithTrash;
    
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            player.KitchenObject.DestroySelf();
            player.ClearKitchenObject();
            OnPlayerInteractWithTrash?.Invoke(this, EventArgs.Empty);
        }
    }
}
