using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IKitchenObjectParent
{
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public Counter SelectedCounter;
    }
    
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public static Player Instance { get; private set; }
    
    public KitchenObject KitchenObject
    {
        get => kitchenObject;
        set => SetKitchenObject(value);
    }
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask interactionLayerMask;
    [SerializeField] private Transform kitchenObjectCarryTransform;
    
    private bool isWalking;
    private Vector3 lastInteractDirection;
    private Counter selectedCounter;
    private KitchenObject kitchenObject;
    


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameInput.OnInteractAction += GameInputOnOnInteractAction;
        gameInput.OnInteractSecondaryAction += GameInputOnOnInteractSecondaryAction;
    }
    
    private void Update()
    {
        HandleMovement();
        HandleInteractions();
    }

    private void GameInputOnOnInteractAction(object sender, EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.Interact(this);
        }
    }
    
    private void GameInputOnOnInteractSecondaryAction(object sender, EventArgs e)
    {
        if (selectedCounter != null)
        {
            selectedCounter.InteractSecondary(this);
        }
    }
    
    private void HandleMovement()
    {
        var inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        var moveDistance = moveSpeed * Time.deltaTime;
        var playerRadius = .7f;
        var playerHeight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirection, moveDistance);
        
        isWalking = moveDirection != Vector3.zero;

        if (!canMove)
        {
            var moveDirectionX = new Vector3(moveDirection.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionX, moveDistance);

            if (canMove)
            {
                moveDirection = moveDirectionX;
            }
            else
            {
                var moveDirectionZ = new Vector3(0, 0, moveDirection.z);
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirectionX, moveDistance);

                if (canMove)
                {
                    moveDirection = moveDirectionZ;
                }
            }
            
        }
        
        if (canMove)
        {
            transform.position += moveDirection * moveSpeed * Time.deltaTime;
        }
        
        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward,moveDirection, Time.deltaTime * rotateSpeed);

    }

    private void HandleInteractions()
    {
        var inputVector = gameInput.GetMovementVectorNormalized();
        
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        if (moveDirection != Vector3.zero)
        {
            lastInteractDirection = moveDirection;
        }
        
        var interactDistance = 2f;
        if (Physics.Raycast(transform.position, lastInteractDirection, out RaycastHit hit,interactDistance, interactionLayerMask))
        {
            if (hit.transform.TryGetComponent(out Counter counter))
            {
                if (counter != selectedCounter)
                {
                    SetSelectedCounter(counter);
                }
            }
            else
            {
                SetSelectedCounter(null);
            }
        }
        else
        {
            SetSelectedCounter(null);
        }
        

        
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    private void SetSelectedCounter(Counter counter)
    {
        selectedCounter = counter;
        
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs()
        {
            SelectedCounter = selectedCounter
        });
    }
    
    public Transform GetKitchenObjectCarryTransform()
    {
        return kitchenObjectCarryTransform;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }

    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
    
    private void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    private KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
}
