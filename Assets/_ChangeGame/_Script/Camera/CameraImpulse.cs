using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.CameraImpulse
{
    public class CameraImpulse : MonoBehaviour
    {
        [SerializeField] private CameraImpulseSO _cameraImpulseSO;
        [SerializeField] private float _smallAmplitude = 1;
        [SerializeField] private float _mediumAmplitude = 2;
        [SerializeField] private float _largeAmplitude = 3;

        private  CinemachineImpulseSource _source;
        private float _normaLImpulseTime;

        private void Start()
        {
            _source = GetComponent<CinemachineImpulseSource>();
            _normaLImpulseTime = _source.m_ImpulseDefinition.m_TimeEnvelope.m_SustainTime;
        }

        private void OnEnable()
        {
            _cameraImpulseSO.OnCallSmallImpulseEvent += SmallImpulse;
            _cameraImpulseSO.OnCallMediumImpulseEvent += MediumImpulse;
            _cameraImpulseSO.OnCallLargeImpulseEvent += LargeImpulse;
            _cameraImpulseSO.OnCallSmallImpulseEventWithTime += SmallImpulse;
            _cameraImpulseSO.OnCallMediumImpulseEventWithTime += MediumImpulse;
            _cameraImpulseSO.OnCallLargeImpulseEventWithTime += LargeImpulse;
        }

        private void OnDisable()
        {
            _cameraImpulseSO.OnCallSmallImpulseEvent -= SmallImpulse;
            _cameraImpulseSO.OnCallMediumImpulseEvent -= MediumImpulse;
            _cameraImpulseSO.OnCallLargeImpulseEvent -= LargeImpulse;
            _cameraImpulseSO.OnCallSmallImpulseEventWithTime -= SmallImpulse;
            _cameraImpulseSO.OnCallMediumImpulseEventWithTime -= MediumImpulse;
            _cameraImpulseSO.OnCallLargeImpulseEventWithTime -= LargeImpulse;
        }


        public void SmallImpulse()
        {
            _source.m_ImpulseDefinition.m_AmplitudeGain = _smallAmplitude;
            _source.m_ImpulseDefinition.m_TimeEnvelope.m_SustainTime = _normaLImpulseTime;
            _source.GenerateImpulse();
        }

        public void SmallImpulse(float impulseTime)
        {
            //振動時間を変更して振動
            
            _source.m_ImpulseDefinition.m_AmplitudeGain = _smallAmplitude;
            _source.m_ImpulseDefinition.m_TimeEnvelope.m_SustainTime = impulseTime;
            _source.GenerateImpulse();
        }

        public void MediumImpulse()
        {
            _source.m_ImpulseDefinition.m_AmplitudeGain = _mediumAmplitude;
            _source.m_ImpulseDefinition.m_TimeEnvelope.m_SustainTime = _normaLImpulseTime;
            _source.GenerateImpulse();
        }
        
        public void MediumImpulse(float impulseTime)
        {
            _source.m_ImpulseDefinition.m_AmplitudeGain = _mediumAmplitude;
            _source.m_ImpulseDefinition.m_TimeEnvelope.m_SustainTime = impulseTime;
            _source.GenerateImpulse();
        }

        public void LargeImpulse()
        {
            _source.m_ImpulseDefinition.m_AmplitudeGain = _largeAmplitude;
            _source.m_ImpulseDefinition.m_TimeEnvelope.m_SustainTime = _normaLImpulseTime;
            _source.GenerateImpulse();
        }

        public void LargeImpulse(float impulseTime)
        {
            _source.m_ImpulseDefinition.m_AmplitudeGain = _largeAmplitude;
            _source.m_ImpulseDefinition.m_TimeEnvelope.m_SustainTime = impulseTime;
            _source.GenerateImpulse();
        }
    }

}
