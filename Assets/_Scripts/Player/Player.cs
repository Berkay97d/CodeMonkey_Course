using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event EventHandler<OnSelectedCounterChangedEventArgs> OnSelectedCounterChanged;
    public class OnSelectedCounterChangedEventArgs : EventArgs
    {
        public ClearCounter selectedCounter;
    }

    public static Player Instance { get; private set; }
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private LayerMask interactionLayerMask;
    
    private bool isWalking;
    private Vector3 lastInteractDirection;
    private ClearCounter selectedCounter;


    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        gameInput.OnInteractAction += GameInputOnOnInteractAction;
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
            selectedCounter.Interact();
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
            if (hit.transform.TryGetComponent(out ClearCounter clearCounter))
            {
                if (clearCounter != selectedCounter)
                {
                    SetSelectedCounter(clearCounter);
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

    private void SetSelectedCounter(ClearCounter selectedCounter)
    {
        this.selectedCounter = selectedCounter;
        
        OnSelectedCounterChanged?.Invoke(this, new OnSelectedCounterChangedEventArgs
        {
            selectedCounter = selectedCounter
        });
    }
}
