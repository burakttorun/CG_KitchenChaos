using System;
using ThePrototype.Scripts.Base;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ThePrototype.Scripts
{
    public class EmptyCounterController : MonoBehaviour, IInteractable, IKitchenObjectParent
    {
        [Header("References")] [SerializeField]
        private Transform _instantiatePoint;

        [SerializeField] private Object _kitchenEntityContainer;
        [SerializeField] private GameObject _testCounter;
        [SerializeField] private bool _testing;
        private IKitchenEntity _KitchenEntity => _kitchenEntityContainer as IKitchenEntity;
        private KitchenObjectDefinition _kitchenObjectDefinition;
        private IKitchenObjectParent _testCounterController;

        public KitchenObjectDefinition KitchenObjectDefinition
        {
            get => _kitchenObjectDefinition;
            set { _kitchenObjectDefinition = value; }
        }

        private void Awake()
        {
            _testCounterController = _testCounter.GetComponent<IKitchenObjectParent>();
        }

        //just testing
        private void Update()
        {
            if (_testing && Input.GetKeyDown(KeyCode.T))
            {
                if (_kitchenObjectDefinition != null)
                {
                    _kitchenObjectDefinition.ParentObject = _testCounterController;
                }
            }
        }

        public bool HasKitchenObject()
        {
            return KitchenObjectDefinition != null;
        }

        public void ClearKitchenObject()
        {
            KitchenObjectDefinition = null;
        }

        public Transform GetKitchenObjectFollowTransform()
        {
            return _instantiatePoint;
        }

        public void Interact()
        {
            if (_kitchenObjectDefinition == null)
            {
                Transform kitchenObjectTransform = Instantiate(_KitchenEntity.Prefab, _instantiatePoint);
                kitchenObjectTransform.GetComponent<KitchenObjectDefinition>().ParentObject = this;
            }
        }
    }
}