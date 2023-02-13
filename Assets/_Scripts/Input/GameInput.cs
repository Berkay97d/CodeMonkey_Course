﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    public event EventHandler OnInteractAction;
    
    
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        
        playerInputActions.Player.Enable();
        
        playerInputActions.Player.Interact.performed += InteractOnperformed;
    }

    private void InteractOnperformed(InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this,EventArgs.Empty);
    }

    public Vector2 GetMovementVectorNormalized()
    {
        var inputVector = playerInputActions.Player.Move.ReadValue<Vector2>();
        
        inputVector = inputVector.normalized;

        return inputVector;
    }
    
    
}
