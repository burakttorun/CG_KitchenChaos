using System;
using ThePrototype.Scripts.Base;
using UnityEngine;

namespace ThePrototype.Scripts
{
    public class SelectedCounterVisualController : MonoBehaviour
    {
        private IInteractable _interactable;
        [SerializeField] private GameObject _visualGameObject;

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
            _visualGameObject.SetActive(true);
        }

        private void Hide()
        {
            _visualGameObject.SetActive(false);
        }
    }
}