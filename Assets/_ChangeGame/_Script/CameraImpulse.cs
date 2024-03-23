using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraImpulse : MonoBehaviour
{
    [SerializeField] private float _smallAmplitude = 1;
    [SerializeField] private float _mediumAmplitude = 2;
    [SerializeField] private float _largeAmplitude = 3;

    private  CinemachineImpulseSource _source;

    private void Start()
    {
        _source = GetComponent<CinemachineImpulseSource>();
    }


    public void SmallImpulse()
    {
        _source.m_ImpulseDefinition.m_AmplitudeGain = _smallAmplitude;
        _source.GenerateImpulse();
    }

    public void MediumImpulse()
    {
        _source.m_ImpulseDefinition.m_AmplitudeGain = _mediumAmplitude;
        _source.GenerateImpulse();
    }

    public void LargeImpulse()
    {
        _source.m_ImpulseDefinition.m_AmplitudeGain = _largeAmplitude;
        _source.GenerateImpulse();
    }


}
