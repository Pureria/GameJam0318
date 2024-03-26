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
        [SerializeField] private Animator _anim;
        
        private RectTransform _rectTran;
        private bool _isPlaying;
        
        private void Start()
        {
            _rectTran = GetComponent<RectTransform>();
            _isPlaying = _PlayOnAwake;

            if (AudioSpectrum.Instance != null)
            {
                _audioSpectrumSO = AudioSpectrum.Instance.audioSpectrumSO;
            }
        }
        
        private void Update()
        {
            if (!_isPlaying) return;
            
            #if UNITY_WEBGL
            #else            
            float spectrumdata = _audioSpectrumSO.SpectrumData[0] + _minScale;
            if(spectrumdata > _maxScale)
            {
                spectrumdata = _maxScale;
            }
            _rectTran.localScale = new Vector3(spectrumdata, spectrumdata, spectrumdata);
            #endif
        }

        public void SetPlay(bool isPlay)
        {
            _isPlaying = isPlay;
            #if UNITY_WEBGL
            _anim.SetTrigger("play");
            #endif
        }
    }
}
