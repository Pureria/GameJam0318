using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.AudioSpectrum
{
    public class AudioSpectrumScale : MonoBehaviour
    {
        [SerializeField] private AudioSpectrumSO _audioSpectrumSO;
        [SerializeField] private RectTransform _rectTran;
        [SerializeField] private float _minScale = 0.8f;
        [SerializeField] private float _maxScale = 1.2f;

        private void Update()
        {
            float spectrumdata = _audioSpectrumSO.SpectrumData[0] + _minScale;
            if(spectrumdata > _maxScale)
            {
                spectrumdata = _maxScale;
            }
            _rectTran.localScale = new Vector3(spectrumdata, spectrumdata, spectrumdata);
        }
    }
}
