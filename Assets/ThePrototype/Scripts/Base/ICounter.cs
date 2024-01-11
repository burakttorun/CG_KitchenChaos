using UnityEngine;

namespace ThePrototype.Scripts.Base
{
    public interface ICounter
    {
        public KitchenObjectDefinition KitchenObjectDefinition { get; set; }
        public bool HasKitchenObject();
        public void ClearKitchenObject();
        public Transform GetKitchenObjectFollowTransform();
    }
}