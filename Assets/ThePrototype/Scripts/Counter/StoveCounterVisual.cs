using System;
using UnityEngine;

namespace ThePrototype.Scripts.Counter
{
    public class StoveCounterVisual : MonoBehaviour
    {
        [Header("Reference")]
        [SerializeField] private StoveCounterController _stoveCounter;
        [SerializeField] private GameObject _sizzingParticleObject;
        [SerializeField] private GameObject _stoveOnGameObject;

        private void Start()
        {
            _stoveCounter.OnStateChanged += StateChanged;
        }

        private void StateChanged(State state)
        {
            ShowHideItem(state == State.Frying || state == State.Fried);
        }

        private void ShowHideItem(bool status)
        {
            _sizzingParticleObject.SetActive(status);
            _stoveOnGameObject.SetActive(status);
        }

    }
}
