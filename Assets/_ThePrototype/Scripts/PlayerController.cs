using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThePrototype.Scripts
{
    public class PlayerController : MonoBehaviour
    {
        #region CashedData

        private Transform _transform;

        #endregion

        [SerializeField] private float _movementSpeed = 7f;
        [SerializeField] private float _rotationSpeed = 10f;
        private bool _isWalking;
        public bool IsWalking => _isWalking;

        private void Start()
        {
            _transform = transform;
        }

        private void Update()
        {
            Vector2 inputVector = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                inputVector.y += 1;
            }

            if (Input.GetKey(KeyCode.S))
            {
                inputVector.y -= 1;
            }

            if (Input.GetKey(KeyCode.D))
            {
                inputVector.x += 1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                inputVector.x -= 1;
            }

            inputVector.Normalize();
            Vector3 moveDir = new Vector3(inputVector.x, 0f, inputVector.y);
            _isWalking = moveDir != Vector3.zero;

            _transform.position += moveDir * (Time.deltaTime * _movementSpeed);

            _transform.forward = Vector3.Slerp(_transform.forward, moveDir, Time.deltaTime * _rotationSpeed);
        }
    }
}