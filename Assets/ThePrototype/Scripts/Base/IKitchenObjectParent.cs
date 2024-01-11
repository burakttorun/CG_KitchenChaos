using UnityEngine;

namespace ThePrototype.Scripts.Base
{
    public interface IKitchenObjectParent
    {
        public KitchenObject KitchenObject { get; set; }
        public bool HasKitchenObject();
        public void ClearKitchenObject();
        public Transform GetKitchenObjectFollowTransform();
    }
}