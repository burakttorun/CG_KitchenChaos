using System.Collections.Generic;
using ThePrototype.Scripts.Base;
using UnityEngine;

namespace ThePrototype.Scripts
{
    public class CuttingCounterController : BaseCounter
    {
        [SerializeField] private List<CuttingRecipeSettings> _cuttingRecipesList;

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
                if (HasKitchenObject() &&
                    _cuttingRecipesList.Exists(x => x.UnslicedObject == KitchenObject.KitchenObjectSettings))
                {
                    KitchenObjectSettings slicedObjectPrefab =
                        GetSlicedObjectDependOnInput(KitchenObject.KitchenObjectSettings);
                    KitchenObject.DestroySelf();
                    KitchenObject.SpawnKitchenObject(slicedObjectPrefab,
                        this);
                }
            }
        }

        private KitchenObjectSettings GetSlicedObjectDependOnInput(KitchenObjectSettings input)
        {
            return _cuttingRecipesList.Find(x => x.UnslicedObject == input).SlicedObject;
        }
    }
}