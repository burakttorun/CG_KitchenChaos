using System;
using ThePrototype.Scripts.Base;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace ThePrototype.Scripts
{
    public class EmptyCounterController : KitchenObjectParent, IInteractable
    {
        [SerializeField] private Object _kitchenEntityContainer;
        private IKitchenEntity _KitchenEntity => _kitchenEntityContainer as IKitchenEntity;

        public void Interact(IInteractor interactor)
        {
            if (_kitchenObject == null)
            {
                Transform kitchenObjectTransform = Instantiate(_KitchenEntity.Prefab, _kitchenObjectHoldPoint);
                kitchenObjectTransform.GetComponent<KitchenObject>().ParentObject = this;
            }
            else
            {
                _kitchenObject.ParentObject = interactor as PlayerController;

            }
        }
    }
}