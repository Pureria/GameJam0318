using System.Collections;
using System.Collections.Generic;
using ChangeGame.AudioSpectrum;
using UnityEngine;
using UnityEngine.UI;

public class DebugAudioSpectrum : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Text _text2;
    [SerializeField] private AudioSpectrumSO _audioSpectrumSO;

    private void Update()
    {
        _text.text = "SpectrumData : " + _audioSpectrumSO.SpectrumData[0];
        _text2.text = "InstanceData : " + AudioSpectrumMaterialSetter.Instance.AudioSpectrumSO.SpectrumData[0];
    }
}
