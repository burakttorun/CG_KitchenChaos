using UnityEngine;

namespace ThePrototype.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        #region CashedData

        private Transform _transform;

        #endregion

        [Header("References")] [SerializeField]
        private InputManager.InputManager _inputManager;

        [Header("Settings")] [SerializeField] private float _movementSpeed = 7f;
        [SerializeField] private float _rotationSpeed = 10f;
        [SerializeField] private float _playerRadius = 0.9f;
        [SerializeField] private float _playerHeight = 2f;
        private bool _isWalking;
        private float _moveDistance;
        public bool IsWalking => _isWalking;

        private void Start()
        {
            _transform = transform;
        }

        private void Update()
        {
            Vector2 inputVector = _inputManager.GetMovementVectorNormalized();
            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
            _isWalking = moveDir != Vector3.zero;
            _moveDistance = Time.deltaTime * _movementSpeed;
            bool canMove = !CapsuleRayCast(moveDir);

            if (!canMove)
            {
                Vector3 moveDirX = new Vector3(moveDir.x, 0, 0);
                canMove = !CapsuleRayCast(moveDirX);
                if (canMove)
                {
                    moveDir = moveDirX;
                }
                else
                {
                    Vector3 moveDirZ = new Vector3(0, 0, moveDir.z);
                    canMove = !CapsuleRayCast(moveDirZ);
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

        private bool CapsuleRayCast(Vector3 moveDir)
        {
            return Physics.CapsuleCast(_transform.position, _transform.position + Vector3.up * _playerHeight,
                _playerRadius, moveDir, _moveDistance);
        }
    }
}