using System;
using UnityEngine;

namespace ThePrototype.Scripts
{
    public enum LookAtMode
    {
        LookAt,
        LookAtInverted,
        CameraForward,
        CameraForwardInverted
    }

    public class LookAtCamera : MonoBehaviour
    {
        [Header("References")] [SerializeField]
        private LookAtMode _mode;

        #region CashedData

        private Transform _transform;
        private Camera _mainCamera;

        #endregion

        private void Awake()
        {
            _transform = transform;
            _mainCamera = Camera.main;
        }

        private void LateUpdate()
        {
            switch (_mode)
            {
                case LookAtMode.LookAt:
                    _transform.LookAt(_mainCamera.transform);
                    break;
                case LookAtMode.LookAtInverted:
                    Vector3 directionFromCamera = _transform.position - _mainCamera.transform.position;
                    _transform.LookAt(_transform.position + directionFromCamera);
                    break;
                case LookAtMode.CameraForward:
                    _transform.forward = _mainCamera.transform.forward;
                    break;
                case LookAtMode.CameraForwardInverted:
                    _transform.forward = -_mainCamera.transform.forward;
                    break;
            }
        }
    }
}