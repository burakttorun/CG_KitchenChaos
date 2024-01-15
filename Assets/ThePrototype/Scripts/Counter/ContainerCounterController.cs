using System;
using ThePrototype.Scripts.Base;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ThePrototype.Scripts.Counter
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

                    KitchenObject.SpawnKitchenObject(_KitchenEntity, kitchenObjectParent);
                    OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }
}