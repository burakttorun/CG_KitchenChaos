using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThePrototype.Scripts
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        private static readonly int IsWalking = Animator.StringToHash("IsWalking");
        [SerializeField] private PlayerController _playerController;
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            _animator.SetBool(IsWalking, _playerController.IsWalking);
        }
    }
}