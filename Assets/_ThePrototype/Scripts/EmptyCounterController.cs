using ThePrototype.Scripts.Base;
using UnityEngine;

namespace ThePrototype.Scripts
{
    public class EmptyCounterController : MonoBehaviour , IInteractable
    {
        public void Interact()
        {
            Debug.Log("interacted with ->" + this.transform.name);
        }
    }
}
