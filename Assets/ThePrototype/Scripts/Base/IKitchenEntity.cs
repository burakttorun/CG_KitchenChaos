using UnityEngine;

namespace ThePrototype.Scripts.Base
{
    public interface IKitchenEntity
    {
        public Transform Prefab { get; set; }
        public Sprite Sprite { get; set; }
        public string ObjectName { get; set; }
    }
}