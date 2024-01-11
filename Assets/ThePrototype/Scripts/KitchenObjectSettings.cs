using System;
using ThePrototype.Scripts.Base;
using UnityEngine;

namespace ThePrototype.Scripts
{
    [CreateAssetMenu(fileName = "Kitchen Object", menuName = "ThePrototype/Scriptable Objects/Kitchen Objects")]
    [Serializable]
    public class KitchenObjectSettings : ScriptableObject, IKitchenEntity
    {
        [SerializeField] private Transform _prefab;

        public Transform Prefab
        {
            get => _prefab;
            set { _prefab = value; }
        }

        [SerializeField] private Sprite _sprite;

        public Sprite Sprite
        {
            get => _sprite;
            set { _sprite = value; }
        }

        [SerializeField] private string _objectName;

        public string ObjectName
        {
            get => _objectName;
            set { _objectName = value; }
        }
    }
}