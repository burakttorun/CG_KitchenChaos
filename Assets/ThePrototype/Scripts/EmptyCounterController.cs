using ThePrototype.Scripts.Base;
using UnityEngine;

namespace ThePrototype.Scripts
{
    public class EmptyCounterController : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform _instantiatePoint;
        [SerializeField] private Object _kitchenEntityContainer;

        private IKitchenEntity _KitchenEntity => _kitchenEntityContainer as IKitchenEntity;
        private KitchenObjectDefinition _kitchenObjectDefinition;

        public void Interact()
        {
            if (_kitchenObjectDefinition == null)
            {
                Transform kitchenObjectTransform = Instantiate(_KitchenEntity.Prefab, _instantiatePoint);
                kitchenObjectTransform.localPosition = Vector3.zero;
                _kitchenObjectDefinition = kitchenObjectTransform.GetComponent<KitchenObjectDefinition>();
            }
        }
    }
}