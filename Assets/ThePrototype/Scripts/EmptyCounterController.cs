using ThePrototype.Scripts.Base;
using UnityEngine;

namespace ThePrototype.Scripts
{
    public class EmptyCounterController : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform _instantiatePoint;
        [SerializeField] private Object _kitchenEntityContainer;

        private IKitchenEntity _KitchenEntity => _kitchenEntityContainer as IKitchenEntity;

        public void Interact()
        {
            Transform kitchenObjectTransform = Instantiate(_KitchenEntity.Prefab, _instantiatePoint);
            kitchenObjectTransform.localPosition = Vector3.zero;
            Debug.Log(kitchenObjectTransform.GetComponent<KitchenObjectDefinition>().KitchenObjectSettings.ObjectName);
        }
    }
}