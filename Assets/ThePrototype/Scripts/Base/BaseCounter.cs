using UnityEngine;

namespace ThePrototype.Scripts.Base
{
    public abstract class BaseCounter : KitchenObjectParent, IInteractable
    {
        
        public abstract void Interact(IInteractor interactor);
    }
}