using System;
using ThePrototype.Scripts.Counter;
using ThePrototype.Scripts.UI.Base;
using UnityEngine;
using UnityEngine.UI;

namespace ThePrototype.Scripts.UI
{
    public class ProgressBarUI : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private Image _barImage;

        private IHasProgress _progressiveCounter;

        protected IHasProgress ProgressiveCounter
        {
            get => _progressiveCounter;
            set { _progressiveCounter = value; }
        }

        [SerializeField] private GameObject _progressiveGameObject;

        private void Awake()
        {
            ProgressiveCounter = _progressiveGameObject.GetComponent<IHasProgress>();
        }

        private void Start()
        {
            _progressiveCounter.OnProgressChanged += CuttingProgressChanged;
            _progressiveCounter.OnHasKitchenObjectStatusChanged += HasKitchenObjectStatusChanged;
            Hide();
        }

        private void HasKitchenObjectStatusChanged(bool hasObject)
        {
            if (hasObject) return;

            Hide();
        }

        private void CuttingProgressChanged(float fillAmount)
        {
            if (fillAmount == 0 || fillAmount == 1f)
            {
                Hide();
            }
            else
            {
                Show();
            }

            _barImage.fillAmount = fillAmount;
        }

        private void Show()
        {
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            _barImage.fillAmount = 0;
            gameObject.SetActive(false);
        }
    }
}