using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;

    public event EventHandler OnInteractSecondaryAction;
    
    private PlayerInputActions playerInputActions;
    
    
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        
        playerInputActions.Player.Enable();
        
        playerInputActions.Player.Interact.performed += InteractOnperformed;
        
        playerInputActions.Player.InteractSecondary.performed += InteractSecondaryOnperformed;
    }

    private void InteractSecondaryOnperformed(InputAction.CallbackContext obj)
    {
        OnInteractSecondaryAction?.Invoke(this, EventArgs.Empty);
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
