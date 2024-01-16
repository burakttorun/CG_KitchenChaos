using ThePrototype.Scripts.ScriptableObjects;
using UnityEngine;

namespace ThePrototype.Scripts.Base
{
    public interface IRecipeSetting
    {
        public KitchenObjectSettings InputObject { get; set; }
        public KitchenObjectSettings OutputObject { get; set; }
    }
}