using System;
using UnityEngine;

public class TrashCounter : Counter
{
    public static event EventHandler OnObjectTrash;
    public event EventHandler OnPlayerInteractWithTrash;
    
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            player.KitchenObject.DestroySelf();
            OnObjectTrash?.Invoke(this, EventArgs.Empty);
            OnPlayerInteractWithTrash?.Invoke(this, EventArgs.Empty);
        }
    }
}
