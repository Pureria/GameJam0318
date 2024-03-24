using System.Collections;
using System.Collections.Generic;
using ChangeGame.UI;
using Cinemachine;
using UnityEngine;

namespace ChangeGame.CameraImpulse
{
    public class CameraSensivity : MonoBehaviour
    {
        [SerializeField] private float _baseSensivity = 150f;
        [SerializeField] private CinemachineFreeLook _freeLook;
        [SerializeField] private OptionSO _optionSo;

        private void Update()
        {
            //カメラの感度を_optionSoから取得
            _freeLook.m_XAxis.m_MaxSpeed = _baseSensivity * (_optionSo.MouseSensivity + 1) + 50f;
        }
    }
}
