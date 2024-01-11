using System;
using System.Collections.Generic;
using ThePrototype.Scripts.Base;
using UnityEngine;

namespace ThePrototype.Scripts
{
    public class SelectedCounterVisualController : MonoBehaviour
    {
        private IInteractable _interactable;
        [SerializeField] private List<GameObject> _visualGameObjects;

        private void Start()
        {
            _interactable = GetComponentInParent<IInteractable>();
            PlayerController.Instance.OnSelectedInteractableChanged += ChangeVisibilityOfSelectedInteractable;
        }

        private void ChangeVisibilityOfSelectedInteractable(object sender, OnSelectedInteractableChangedEventArgs e)
        {
            if (_interactable == e.selectedInteractable)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        private void Show()
        {
            _visualGameObjects.ForEach(x => x.SetActive(true));
        }

        private void Hide()
        {
            _visualGameObjects.ForEach(x => x.SetActive(false));
        }
    }
}