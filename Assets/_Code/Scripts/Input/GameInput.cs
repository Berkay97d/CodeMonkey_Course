using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameInput : MonoBehaviour
{
    public event EventHandler OnInteractAction;
    public event EventHandler OnInteractSecondaryAction;
    public event EventHandler OnPause;

    public static GameInput Instance { get; private set; }
    
    
    
    private PlayerInputActions playerInputActions;
    
    
    private void Awake()
    {
        Instance = this;
        
        playerInputActions = new PlayerInputActions();
        
        playerInputActions.Player.Enable();
        
        playerInputActions.Player.Interact.performed += InteractOnperformed;
        
        playerInputActions.Player.InteractSecondary.performed += InteractSecondaryOnperformed;
        
        playerInputActions.Player.Pause.performed += PauseOnperformed;
    }

    private void PauseOnperformed(InputAction.CallbackContext obj)
    {
        OnPause?.Invoke(this, EventArgs.Empty);
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
