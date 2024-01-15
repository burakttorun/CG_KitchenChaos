using System.Collections.Generic;
using ThePrototype.Scripts.Base;
using UnityEngine;

namespace ThePrototype.Scripts
{
    public class CuttingCounterController : BaseCounter
    {
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
        }

        public void InteractAlternate(IInteractor interactor)
        {
            if (interactor is KitchenObjectParent kitchenObjectParent)
            {
                CuttingRecipeSettings currentRecipeSettings =
                    _cuttingRecipesList.Find(x => x.UnslicedObject == KitchenObject.KitchenObjectSettings);
                if (HasKitchenObject() && currentRecipeSettings != null)
                {
                    _cuttingProgress++;
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

        private KitchenObjectSettings GetSlicedObjectDependOnInput(KitchenObjectSettings input)
        {
            return _cuttingRecipesList.Find(x => x.UnslicedObject == input).SlicedObject;
        }
    }
}