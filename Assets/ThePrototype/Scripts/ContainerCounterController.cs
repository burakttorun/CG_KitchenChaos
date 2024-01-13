using System;
using ThePrototype.Scripts.Base;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ThePrototype.Scripts
{
    public class ContainerCounterController : BaseCounter
    {
        [SerializeField] private Object _kitchenEntityContainer;
        protected IKitchenEntity _KitchenEntity => _kitchenEntityContainer as IKitchenEntity;

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