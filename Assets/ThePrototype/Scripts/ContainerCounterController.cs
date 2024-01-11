using System;
using ThePrototype.Scripts.Base;
using UnityEngine;

namespace ThePrototype.Scripts
{
    public class ContainerCounterController : BaseCounter
    {
        public event EventHandler OnPlayerGrabbedObject;

        public override void Interact(IInteractor interactor)
        {
            if (_kitchenObject == null)
            {
                Transform kitchenObjectTransform = Instantiate(_KitchenEntity.Prefab, _kitchenObjectHoldPoint);
                kitchenObjectTransform.GetComponent<KitchenObject>().ParentObject = interactor as PlayerController;
                OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}