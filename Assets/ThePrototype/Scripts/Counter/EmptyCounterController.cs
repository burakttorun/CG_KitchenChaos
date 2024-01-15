using ThePrototype.Scripts.Base;

namespace ThePrototype.Scripts.Counter
{
    public class EmptyCounterController : BaseCounter
    {
        public override void Interact(IInteractor interactor)
        {
            if (interactor is PlayerController playerController)
            {
                if (!this.HasKitchenObject())
                {
                    if (!playerController.HasKitchenObject()) return;
                    else
                    {
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
    }
}