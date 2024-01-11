using UnityEngine;

namespace ThePrototype.Scripts.Base
{
    public abstract class KitchenObjectParent : MonoBehaviour, IKitchenObjectParent
    {
        [Header("References")] [SerializeField]
        protected Transform _kitchenObjectHoldPoint;

        protected KitchenObject _kitchenObject;

        public KitchenObject KitchenObject
        {
            get => _kitchenObject;
            set { _kitchenObject = value; }
        }

        public bool HasKitchenObject()
        {
            return KitchenObject != null;
        }

        public void ClearKitchenObject()
        {
            KitchenObject = null;
        }

        public Transform GetKitchenObjectFollowTransform()
        {
            return _kitchenObjectHoldPoint;
        }
    }
}