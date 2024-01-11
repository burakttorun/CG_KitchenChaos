using UnityEngine;

namespace ThePrototype.Scripts.Base
{
    public abstract class BaseCounter : KitchenObjectParent, IInteractable
    {
        [SerializeField] private Object _kitchenEntityContainer;
        protected IKitchenEntity _KitchenEntity => _kitchenEntityContainer as IKitchenEntity;

        public abstract void Interact(IInteractor interactor);
    }
}