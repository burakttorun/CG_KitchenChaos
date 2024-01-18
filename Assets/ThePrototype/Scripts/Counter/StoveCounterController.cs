using System;
using System.Collections.Generic;
using ThePrototype.Scripts.Base;
using ThePrototype.Scripts.ScriptableObjects;
using ThePrototype.Scripts.UI.Base;
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

    public class StoveCounterController : BaseCounter, IHasProgress
    {
        public event Action<float> OnProgressChanged;
        public event Action<bool> OnHasKitchenObjectStatusChanged;

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
                        OnProgressChanged?.Invoke(_fryingProgress);
                        break;
                    case State.Frying:
                        _fryingProgress += Time.deltaTime;
                        OnProgressChanged?.Invoke(_fryingProgress / _currentFryingRecipeSettings.FryingTimerMax);
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
                        OnProgressChanged?.Invoke(_fryingProgress / _currentFryingRecipeSettings.FryingTimerMax);
                        if (_fryingProgress >= _currentFryingRecipeSettings.FryingTimerMax)
                        {
                            KitchenObject.DestroySelf();
                            KitchenObject.SpawnKitchenObject(_currentFryingRecipeSettings.OutputObject, this);
                            _state = State.Burned;
                        }

                        break;

                    case State.Burned:
                        _fryingProgress = 0;
                        OnProgressChanged?.Invoke(_fryingProgress);
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
                        _fryingProgress = 0;
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

            OnHasKitchenObjectStatusChanged?.Invoke(HasKitchenObject());
        }

        protected FryingRecipeSettings FindCurrentRecipeSettings(List<FryingRecipeSettings> recipeLists)
        {
            return recipeLists.Find(x => x.InputObject == KitchenObject.KitchenObjectSettings);
        }
    }
}