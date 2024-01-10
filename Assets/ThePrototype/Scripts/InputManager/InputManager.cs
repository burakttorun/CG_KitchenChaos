using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace ThePrototype.Scripts.InputManager
{
    [CreateAssetMenu(fileName = "InputManager", menuName = "ThePrototype/Input/InputManager")]
    public class InputManager : ScriptableObject, PlayerInputActions.IPlayerActions
    {
        public event UnityAction<Vector2> Move = delegate { };
        public event Action<bool> Interact = delegate { };
        private PlayerInputActions _playerInputActions;

        public Vector2 MovementDirection => _playerInputActions.Player.Move.ReadValue<Vector2>();

        private void OnEnable()
        {
            if (_playerInputActions == null)
            {
                _playerInputActions = new PlayerInputActions();
                _playerInputActions.Player.SetCallbacks(this);
            }

            _playerInputActions.Enable();
        }

        public Vector2 GetMovementVectorNormalized()
        {
            return MovementDirection.normalized;
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            Move.Invoke(context.ReadValue<Vector2>());
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            switch (context.phase)
            {
                case InputActionPhase.Started:
                    Interact?.Invoke(true);
                    break;
                case InputActionPhase.Canceled:
                    Interact?.Invoke(false);
                    break;
            }
        }
    }
}