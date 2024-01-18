using System;
using System.Collections.Generic;
using ThePrototype.Scripts.Base;
using ThePrototype.Scripts.ScriptableObjects;
using Unity.VisualScripting;
using UnityEngine;

namespace ThePrototype.Scripts.Counter
{
    enum State
    {
        Idle,
        Frying,
        Fried,
        Burned
    }

    public class StoveCounterController : BaseCounter
    {
        [Header("References")] [SerializeField]
        private List<FryingRecipeSettings> _fryingRecipesList;

        private State _state;
        private float _fryingProgress;
        private FryingRecipeSettings _currentFryingRecipeSettings;

        private void Start()
        {
            _state = State.Idle;
            _fryingProgress = 0;
        }

        private void Update()
        {
            if (HasKitchenObject())
            {
                switch (_state)
                {
                    case State.Idle:
                        _fryingProgress = 0;
                        break;
                    case State.Frying:
                        _fryingProgress += Time.deltaTime;
                        if (_fryingProgress >= _currentFryingRecipeSettings.FryingTimerMax)
                        {
                            KitchenObject.DestroySelf();
                            KitchenObject.SpawnKitchenObject(_currentFryingRecipeSettings.OutputObject, this);
                            _fryingProgress = 0;
                            _currentFryingRecipeSettings = FindCurrentRecipeSettings(_fryingRecipesList);
                            _state = _currentFryingRecipeSettings == null ? State.Idle : State.Fried;
                        }

                        break;
                    case State.Fried:
                        _fryingProgress += Time.deltaTime;
                        if (_fryingProgress >= _currentFryingRecipeSettings.FryingTimerMax)
                        {
                            KitchenObject.DestroySelf();
                            KitchenObject.SpawnKitchenObject(_currentFryingRecipeSettings.OutputObject, this);
                            _state = State.Burned;
                        }

                        break;

                    case State.Burned:
                        _fryingProgress = 0;
                        break;
                }
            }
        }

        public override void Interact(IInteractor interactor)
        {
            if (interactor is PlayerController playerController)
            {
                if (!this.HasKitchenObject())
                {
                    if (!playerController.HasKitchenObject()) return;
                    else
                    {
                        if (!_fryingRecipesList.Exists(x =>
                                x.InputObject == playerController.KitchenObject.KitchenObjectSettings))
                            return;

                        playerController.KitchenObject.ParentObject = this;
                        _currentFryingRecipeSettings = FindCurrentRecipeSettings(_fryingRecipesList);
                        _state = State.Frying;
                    }
                }
                else
                {
                    if (playerController.HasKitchenObject()) return;
                    else
                    {
                        this.KitchenObject.ParentObject = playerController;
                        _state = State.Idle;
                    }
                }
            }
        }

        protected FryingRecipeSettings FindCurrentRecipeSettings(List<FryingRecipeSettings> recipeLists)
        {
            return recipeLists.Find(x => x.InputObject == KitchenObject.KitchenObjectSettings);
        }
    }
}