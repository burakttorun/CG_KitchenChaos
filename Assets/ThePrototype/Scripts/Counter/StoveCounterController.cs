using System.Collections.Generic;
using ThePrototype.Scripts.Base;
using ThePrototype.Scripts.ScriptableObjects;
using UnityEngine;

namespace ThePrototype.Scripts.Counter
{
    public class StoveCounterController : CuttingCounterController
    {
        [Header("References")] [SerializeField]
        private List<FryingRecipeSettings> _fryingRecipesList;

        private float _fryingProgress;

        public override void Interact(IInteractor interactor)
        {
            Interact(interactor, new List<IRecipeSetting>(_fryingRecipesList), ref _fryingProgress);
        }

        public override void InteractAlternate(IInteractor interactor)
        {
            InteractAlternate(interactor, new List<IRecipeSetting>(_fryingRecipesList), ref _fryingProgress);
        }
    }
}