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
                if (interactor is IKitchenObjectParent kitchenObjectParent)
                {
                    if (kitchenObjectParent.HasKitchenObject()) return;
                    Transform kitchenObjectTransform = Instantiate(_KitchenEntity.Prefab, _kitchenObjectHoldPoint);
                    kitchenObjectTransform.GetComponent<KitchenObject>().ParentObject = kitchenObjectParent;
                    OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}