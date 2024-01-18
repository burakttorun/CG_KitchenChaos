using System;
using System.Collections.Generic;
using ThePrototype.Scripts.Base;
using ThePrototype.Scripts.ScriptableObjects;
using ThePrototype.Scripts.UI.Base;
using UnityEngine;

namespace ThePrototype.Scripts.Counter
{
    public class CuttingCounterController : BaseCounter,IHasProgress
    {
        public event Action<float> OnProgressChanged;
        public event Action<bool> OnHasKitchenObjectStatusChanged;

        [Header("References")] [SerializeField]
        private List<CuttingRecipeSettings> _cuttingRecipesList;

        private int _cuttingProgress;

        public override void Interact(IInteractor interactor)
        {
            Interact(interactor, new List<IRecipeSetting>(_cuttingRecipesList), ref _cuttingProgress);
        }

        protected void Interact(IInteractor interactor, List<IRecipeSetting> recipeSettingList, ref int progressValue)
        {
            if (interactor is PlayerController playerController)
            {
                if (!this.HasKitchenObject())
                {
                    if (!playerController.HasKitchenObject()) return;
                    else
                    {
                        if (!recipeSettingList.Exists(x =>
                                x.InputObject == playerController.KitchenObject.KitchenObjectSettings))
                            return;

                        playerController.KitchenObject.ParentObject = this;
                        progressValue = 0;
                        OnProgressChanged?.Invoke(progressValue);
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
            InteractAlternate(interactor, new List<IRecipeSetting>(_cuttingRecipesList), ref _cuttingProgress);
        }

        protected void InteractAlternate(IInteractor interactor, List<IRecipeSetting> recipeLists,
            ref int progressValue)
        {
            if (interactor is KitchenObjectParent kitchenObjectParent)
            {
                if (HasKitchenObject())
                {
                    CuttingRecipeSettings currentRecipeSettings =
                        FindCurrentRecipeSettings(recipeLists) as
                            CuttingRecipeSettings;

                    if (currentRecipeSettings != null)
                    {
                        progressValue++;
                        OnProgressChanged?.Invoke((float)_cuttingProgress /
                                                  currentRecipeSettings.CuttingProgressMax);
                        if (progressValue >= currentRecipeSettings.CuttingProgressMax)
                        {
                            KitchenObjectSettings slicedObjectPrefab =
                                GetOutputObjectDependOnInput(KitchenObject.KitchenObjectSettings,
                                    recipeLists);
                            KitchenObject.DestroySelf();
                            KitchenObject.SpawnKitchenObject(slicedObjectPrefab,
                                this);
                        }
                    }
                }
            }
        }

        protected IRecipeSetting FindCurrentRecipeSettings(List<IRecipeSetting> recipeLists)
        {
            return recipeLists.Find(x => x.InputObject == KitchenObject.KitchenObjectSettings);
        }

        protected KitchenObjectSettings GetOutputObjectDependOnInput(KitchenObjectSettings input,
            List<IRecipeSetting> recipeLists)
        {
            return recipeLists.Find(x => x.InputObject == input).OutputObject;
        }
    }
}