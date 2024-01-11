using UnityEngine;

namespace ThePrototype.Scripts
{
    public class KitchenObjectDefinition : MonoBehaviour
    {
        [SerializeField] private KitchenObjectSettings _kitchenObjectSettings;

        public KitchenObjectSettings KitchenObjectSettings => _kitchenObjectSettings;
    }
}