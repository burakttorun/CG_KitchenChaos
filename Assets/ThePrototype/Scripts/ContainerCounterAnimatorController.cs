using System;
using UnityEngine;

namespace ThePrototype.Scripts
{
    public class ContainerCounterAnimatorController : MonoBehaviour
    {
        
        private ContainerCounterController _containerCounterController;
        private Animator _animator;
        private readonly int _openClose = Animator.StringToHash("OpenClose");

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _containerCounterController = GetComponentInParent<ContainerCounterController>();
        }

        private void Start()
        {
            _containerCounterController.OnPlayerGrabbedObject += OnPlayerGrabbedObject;
        }

        private void OnPlayerGrabbedObject(object sender, EventArgs e)
        {
            _animator.SetTrigger(_openClose);
        }
    }
}