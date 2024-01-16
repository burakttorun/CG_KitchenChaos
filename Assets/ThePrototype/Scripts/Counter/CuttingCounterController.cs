using System;
using System.Collections.Generic;
using ThePrototype.Scripts.Base;
using UnityEngine;

namespace ThePrototype.Scripts.Counter
{
    public class CuttingCounterController : BaseCounter
    {
        public event Action<float> OnCuttingProgressChanged;
        public event Action<bool> OnHasKitchenObjectStatusChanged;

        [Header("References")] [SerializeField]
        private List<CuttingRecipeSettings> _cuttingRecipesList;

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
                                x.UnslicedObject == playerController.KitchenObject.KitchenObjectSettings))
                            return;

                        playerController.KitchenObject.ParentObject = this;
                        _cuttingProgress = 0;
                        OnCuttingProgressChanged?.Invoke(_cuttingProgress);
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

        public void InteractAlternate(IInteractor interactor)
        {
            if (interactor is KitchenObjectParent kitchenObjectParent)
            {
                if (HasKitchenObject())
                {
                    CuttingRecipeSettings currentRecipeSettings =
                        _cuttingRecipesList.Find(x => x.UnslicedObject == KitchenObject.KitchenObjectSettings);

                    if (currentRecipeSettings != null)
                    {
                        _cuttingProgress++;
                        OnCuttingProgressChanged?.Invoke((float)_cuttingProgress /
                                                         currentRecipeSettings.CuttingProgressMax);
                        if (_cuttingProgress >= currentRecipeSettings.CuttingProgressMax)
                        {
                            KitchenObjectSettings slicedObjectPrefab =
                                GetSlicedObjectDependOnInput(KitchenObject.KitchenObjectSettings);
                            KitchenObject.DestroySelf();
                            KitchenObject.SpawnKitchenObject(slicedObjectPrefab,
                                this);
                        }
                    }
                }
            }
        }

        private KitchenObjectSettings GetSlicedObjectDependOnInput(KitchenObjectSettings input)
        {
            return _cuttingRecipesList.Find(x => x.UnslicedObject == input).SlicedObject;
        }
    }
}