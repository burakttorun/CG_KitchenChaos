using System;
using UnityEngine;

namespace ThePrototype.Scripts.UI.Base
{
    public interface IHasProgress
    {
        public event Action<float> OnProgressChanged;
        public event Action<bool> OnHasKitchenObjectStatusChanged;
    }
}