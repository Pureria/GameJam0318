using System.Collections;
using System.Collections.Generic;
using ChangeGame.UI;
using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChangeGame.CameraImpulse
{
    public class CameraSensivity : MonoBehaviour
    {
        [SerializeField] private float _baseSensivityX = 150f;
        [SerializeField] private float _baseSensivityY = 1f;
        [SerializeField] private CinemachineFreeLook _freeLook;
        [SerializeField] private OptionSO _optionSo;

        private void Update()
        {
            //カメラの感度を_optionSoから取得
            _freeLook.m_XAxis.m_MaxSpeed = _baseSensivityX * ((_optionSo.MouseSensivity + 1.2f) * 0.5f);
            _freeLook.m_YAxis.m_MaxSpeed = _baseSensivityY * ((_optionSo.MouseSensivity + 1.2f) * 0.5f);
        }
    }
}
