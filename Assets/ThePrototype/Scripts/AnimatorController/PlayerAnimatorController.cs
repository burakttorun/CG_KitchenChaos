using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ThePrototype.Scripts.AnimatorController
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        private readonly int IsWalking = Animator.StringToHash("IsWalking");
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