using ThePrototype.Scripts.Base;
using UnityEngine;
using UnityEngine.Serialization;

namespace ThePrototype.Scripts.ScriptableObjects
{
    [CreateAssetMenu(fileName = "Cutting Recipe", menuName = "ThePrototype/Scriptable Objects/Cutting Recipe")]
    public class CuttingRecipeSettings : ScriptableObject, IRecipeSetting
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

        [SerializeField] private int _cuttingProgressMax;

        public int CuttingProgressMax
        {
            get => _cuttingProgressMax;
            set { _cuttingProgressMax = value; }
        }
    }
}