using System;
using ThePrototype.Scripts.Base;
using ThePrototype.Scripts.ScriptableObjects;
using TMPro.EditorUtilities;
using UnityEngine;

namespace ThePrototype.Scripts
{
    public class KitchenObject : MonoBehaviour
    {
        #region CashedDatas

        private Transform _transform;

        #endregion

        [Header("References")] [SerializeField]
        private KitchenObjectSettings _kitchenObjectSettings;

        public KitchenObjectSettings KitchenObjectSettings => _kitchenObjectSettings;


        private IKitchenObjectParent _parentObject;

        public IKitchenObjectParent ParentObject
        {
            get => _parentObject;
            set
            {
                if (_parentObject != null)
                {
                    _parentObject.ClearKitchenObject();
                }

                _parentObject = value;
                if (_parentObject.HasKitchenObject())
                {
                    Debug.LogError("Parent already has a Kitchen Object");
                }

                _parentObject.KitchenObject = this;
                _transform.parent = _parentObject.GetKitchenObjectFollowTransform();
                _transform.localPosition = Vector3.zero;
            }
        }

        private void Awake()
        {
            _transform = transform;
        }

        public void DestroySelf()
        {
            _parentObject.ClearKitchenObject();
            Destroy(gameObject);
        }

        public static KitchenObject SpawnKitchenObject(IKitchenEntity kitchenEntity, IKitchenObjectParent parent)
        {
            Transform kitchenObjectTransform =
                Instantiate(kitchenEntity.Prefab, parent.GetKitchenObjectFollowTransform());
            KitchenObject createdKitchenObject = kitchenObjectTransform.GetComponent<KitchenObject>();
            createdKitchenObject.ParentObject = parent;

            return createdKitchenObject;
        }
    }
}