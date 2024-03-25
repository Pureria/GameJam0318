using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.AudioSpectrum
{
    public class AudioSpectrumScale : MonoBehaviour
    {
        [SerializeField] private AudioSpectrumSO _audioSpectrumSO;
        [SerializeField] private float _minScale = 0.8f;
        [SerializeField] private float _maxScale = 1.2f;
        [SerializeField] private bool _PlayOnAwake = true;
        
        private RectTransform _rectTran;
        private bool _isPlaying;
        
        private void Start()
        {
            _rectTran = GetComponent<RectTransform>();
            _isPlaying = _PlayOnAwake;

            if (AudioSpectrumMaterialSetter.Instance != null)
            {
                _audioSpectrumSO = AudioSpectrumMaterialSetter.Instance.AudioSpectrumSO;
            }
        }
        
        private void Update()
        {
            if (!_isPlaying) return;
            
            float spectrumdata = _audioSpectrumSO.SpectrumData[0] + _minScale;
            if(spectrumdata > _maxScale)
            {
                spectrumdata = _maxScale;
            }
            _rectTran.localScale = new Vector3(spectrumdata, spectrumdata, spectrumdata);
        }

        public void SetPlay(bool isPlay)
        {
            _isPlaying = isPlay;
        }
    }
}
