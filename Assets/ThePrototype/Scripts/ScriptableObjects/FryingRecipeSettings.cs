using ThePrototype.Scripts.Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace ThePrototype.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Frying Recipe", menuName = "ThePrototype/Scriptable Objects/Frying Recipe")]
    public class FryingRecipeSettings : ScriptableObject, IRecipeSetting
    {
        [Header("References")] [SerializeField]
        private KitchenObjectSettings _inputObject;

        public KitchenObjectSettings InputObject
        {
            get => _inputObject;
            set { _inputObject = value; }
        }

        [SerializeField] private KitchenObjectSettings _outputObject;

        public KitchenObjectSettings OutputObject
        {
            get => _outputObject;
            set { _outputObject = value; }
        }

        [Header("Settings")]
        [SerializeField] private float _fryingTimerMax;

        public float FryingTimerMax
        {
            get => _fryingTimerMax;
            set { _fryingTimerMax = value; }
        }
    }
}