using System;
using ThePrototype.Scripts.Base;
using UnityEngine;

namespace ThePrototype.Scripts
{
    public class OnSelectedInteractableChangedEventArgs : EventArgs
    {
        public IInteractable selectedInteractable;
    }

    public class PlayerController : KitchenObjectParent, IInteractor
    {
        public static PlayerController Instance { get; private set; }
        public event EventHandler<OnSelectedInteractableChangedEventArgs> OnSelectedInteractableChanged;

        #region CashedData

        private Transform _transform;

        #endregion

        [Header("References")] [SerializeField]
        private InputManager.InputManager _inputManager;

        [Header("Settings")] [SerializeField] private float _movementSpeed = 7f;
        [SerializeField] private float _rotationSpeed = 10f;
        [SerializeField] private float _playerRadius = 0.9f;
        [SerializeField] private float _playerHeight = 2f;
        [SerializeField] private float _interactDistance = 2f;
        [SerializeField] private LayerMask _interactLayerMask;

        private bool _isWalking;
        private float _moveDistance;
        private Vector3 _lastInteractDirection;
        private IInteractable _selectedInteractable;
        public bool IsWalking => _isWalking;

        private void Awake()
        {
            if (Instance != null)
            {
                Debug.LogError("There is more than one Player Instance!");
            }
            else
            {
                Instance = this;
            }

            _inputManager.Interact += OnInteract;
            _inputManager.InteractAlternate += OnInteractAlternate;
            _transform = transform;
        }

        private void OnInteract(bool isPressed)
        {
            if (!isPressed) return;
            _selectedInteractable?.Interact(this);
        }

        private void OnInteractAlternate(bool isPressed)
        {
            if (!isPressed) return;
            if (_selectedInteractable is CuttingCounterController cuttingCounterController)
            {
                cuttingCounterController.InteractAlternate(this);
            }
        }

        private void Update()
        {
            HandleMovement();
            HandleInteraction();
        }

        private void HandleMovement()
        {
            Vector2 inputVector = _inputManager.GetMovementVectorNormalized();
            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
            _isWalking = moveDir != Vector3.zero;
            _moveDistance = Time.deltaTime * _movementSpeed;
            bool canMove = !CapsuleRayCast(moveDir);

            if (!canMove)
            {
                Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
                canMove = moveDirX.x != 0 && !CapsuleRayCast(moveDirX);
                if (canMove)
                {
                    moveDir = moveDirX;
                }
                else
                {
                    Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                    canMove = moveDirZ.z != 0 && !CapsuleRayCast(moveDirZ);
                    if (canMove)
                    {
                        moveDir = moveDirZ;
                    }
                    else return;
                }
            }

            _transform.position += moveDir * _moveDistance;
            _transform.forward = Vector3.Slerp(_transform.forward, moveDir, Time.deltaTime * _rotationSpeed);
        }

        private void HandleInteraction()
        {
            Vector3 inputVector = _inputManager.GetMovementVectorNormalized();
            Vector3 moveDir = new Vector3(inputVector.x, 0, inputVector.y);

            if (moveDir != Vector3.zero)
            {
                _lastInteractDirection = moveDir;
            }

            if (Physics.Raycast(_transform.position, _lastInteractDirection, out RaycastHit raycastHit,
                    _interactDistance, _interactLayerMask))
            {
                if (raycastHit.transform.TryGetComponent(out IInteractable interactable))
                {
                    if (_selectedInteractable != interactable)
                    {
                        SetSelectedInteractable(interactable);
                    }
                }
                else
                {
                    SetSelectedInteractable(null);
                }
            }
            else
            {
                SetSelectedInteractable(null);
            }
        }

        private bool CapsuleRayCast(Vector3 moveDir)
        {
            return Physics.CapsuleCast(_transform.position, _transform.position + Vector3.up * _playerHeight,
                _playerRadius, moveDir, _moveDistance);
        }

        private void SetSelectedInteractable(IInteractable selectedItem)
        {
            _selectedInteractable = selectedItem;
            OnSelectedInteractableChanged?.Invoke(this,
                new OnSelectedInteractableChangedEventArgs { selectedInteractable = selectedItem });
        }
    }
}