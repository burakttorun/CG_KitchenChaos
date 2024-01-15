using ThePrototype.Scripts.Base;
using UnityEngine;

namespace ThePrototype.Scripts.Counter
{
    public class TrashCounterController : BaseCounter
    {
        public override void Interact(IInteractor interactor)
        {
            if (interactor is PlayerController playerController)
            {
                if (playerController.HasKitchenObject())
                {
                    playerController.KitchenObject.DestroySelf();
                }
            }
        }
    }
}