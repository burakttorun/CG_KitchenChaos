using System;
using ThePrototype.Scripts.Base;
using TMPro.EditorUtilities;
using UnityEngine;

namespace ThePrototype.Scripts
{
    public class KitchenObjectDefinition : MonoBehaviour
    {
        #region CashedDatas

        private Transform _transform;

        #endregion

        [Header("References")]
        [SerializeField] private KitchenObjectSettings _kitchenObjectSettings;
        public KitchenObjectSettings KitchenObjectSettings => _kitchenObjectSettings;


        private ICounter _parentObject;

        public ICounter ParentObject
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
                    Debug.LogError("Counter already has a Kitchen Object");
                }

                _parentObject.KitchenObjectDefinition = this;
                _transform.parent = _parentObject.GetKitchenObjectFollowTransform();
                _transform.localPosition = Vector3.zero;
            }
        }

        private void Awake()
        {
            _transform = transform;
        }
    }
}