using System;
using UnityEngine;
using UnityEngine.UI;

namespace ThePrototype.Scripts.UI
{
    public class CuttingProgressBarUI : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private Image _barImage;

        [SerializeField] private CuttingCounterController _cuttingCounter;

        private void Start()
        {
            _cuttingCounter.OnCuttingProgressChanged += CuttingProgressChanged;
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