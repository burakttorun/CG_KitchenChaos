using System;
using ThePrototype.Scripts.Counter;
using UnityEngine;

namespace ThePrototype.Scripts.AnimatorController
{
    public class CuttingCounterAnimatorController : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private CuttingCounterController _cuttingCounter;

        private Animator _animator;
        private readonly int _cut = Animator.StringToHash("Cut");


        private void Start()
        {
            _animator = GetComponent<Animator>();
            _cuttingCounter.OnProgressChanged += PlayCuttingAnimation;
        }

        private void PlayCuttingAnimation(float progressAmount)
        {
            if (progressAmount == 0f) return;

            _animator.SetTrigger(_cut);
        }
    }
}