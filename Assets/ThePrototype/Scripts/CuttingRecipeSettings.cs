using UnityEngine;

namespace ThePrototype.Scripts
{
    [CreateAssetMenu(fileName = "Cutting Recipe", menuName = "ThePrototype/Scriptable Objects/Cutting Recipe")]
    public class CuttingRecipeSettings : ScriptableObject
    {
        [SerializeField] private KitchenObjectSettings _unslicedObject;

        public KitchenObjectSettings UnslicedObject
        {
            get => _unslicedObject;
            set { _unslicedObject = value; }
        }

        [SerializeField] private KitchenObjectSettings _slicedObject;

        public KitchenObjectSettings SlicedObject
        {
            get => _slicedObject;
            set { _slicedObject = value; }
        }
    }
}