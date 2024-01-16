using System;
using System.Collections.Generic;
using ThePrototype.Scripts.Base;
using ThePrototype.Scripts.ScriptableObjects;
using UnityEngine;

namespace ThePrototype.Scripts.Counter
{
    public class CuttingCounterController : BaseCounter
    {
        public event Action<float> OnProgressChanged;
        public event Action<bool> OnHasKitchenObjectStatusChanged;

        [Header("References")]
        
        [SerializeField] private List<CuttingRecipeSettings> _cuttingRecipesList;

        private int _cuttingProgress;

        public override void Interact(IInteractor interactor)
        {
            if (interactor is PlayerController playerController)
            {
                if (!this.HasKitchenObject())
                {
                    if (!playerController.HasKitchenObject()) return;
                    else
                    {
                        if (!_cuttingRecipesList.Exists(x =>
                                x.InputObject == playerController.KitchenObject.KitchenObjectSettings))
                            return;

                        playerController.KitchenObject.ParentObject = this;
                        _cuttingProgress = 0;
                        OnProgressChanged?.Invoke(_cuttingProgress);
                    }
                }
                else
                {
                    if (playerController.HasKitchenObject()) return;
                    else
                    {
                        this.KitchenObject.ParentObject = playerController;
                    }
                }
            }

            OnHasKitchenObjectStatusChanged?.Invoke(HasKitchenObject());
        }

        public virtual void InteractAlternate(IInteractor interactor)
        {
            if (interactor is KitchenObjectParent kitchenObjectParent)
            {
                if (HasKitchenObject())
                {
                    CuttingRecipeSettings currentRecipeSettings =
                        FindCurrentRecipeSettings() as CuttingRecipeSettings;

                    if (currentRecipeSettings != null)
                    {
                        _cuttingProgress++;
                        OnProgressChanged?.Invoke((float)_cuttingProgress /
                                                  currentRecipeSettings.CuttingProgressMax);
                        if (_cuttingProgress >= currentRecipeSettings.CuttingProgressMax)
                        {
                            KitchenObjectSettings slicedObjectPrefab =
                                GetOutputObjectDependOnInput(KitchenObject.KitchenObjectSettings);
                            KitchenObject.DestroySelf();
                            KitchenObject.SpawnKitchenObject(slicedObjectPrefab,
                                this);
                        }
                    }
                }
            }
        }

        protected IRecipeSetting FindCurrentRecipeSettings()
        {
            return _cuttingRecipesList.Find(x => x.InputObject == KitchenObject.KitchenObjectSettings);
        }

        protected KitchenObjectSettings GetOutputObjectDependOnInput(KitchenObjectSettings input)
        {
            return _cuttingRecipesList.Find(x => x.InputObject == input).OutputObject;
        }
    }
}