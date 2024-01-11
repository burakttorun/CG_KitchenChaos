using UnityEngine;

namespace ThePrototype.Scripts.Base
{
    public interface IKitchenObjectParent
    {
        public KitchenObjectDefinition KitchenObjectDefinition { get; set; }
        public bool HasKitchenObject();
        public void ClearKitchenObject();
        public Transform GetKitchenObjectFollowTransform();
    }
}