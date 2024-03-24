using System;
using System.Collections;
using System.Collections.Generic;
using ChangeGame.UI;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Serialization;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
        
        [SerializeField] private AudioMixer _audioMixer;
        [SerializeField] private OptionSO _optionSO;
        [SerializeField] private AudioSource _bgmSource;
        [SerializeField] private List<AudioClip> _audioClips = new List<AudioClip>();

        private bool _isPlayerBGM;
        private int _nowBGMIndex;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
            }
        }

        private void OnEnable()
        {
            _optionSO.OnChangeAnyVolumeEvent += CheckAllVolume;
        }

        private void OnDisable()
        {
            _optionSO.OnChangeAnyVolumeEvent -= CheckAllVolume;
        }

        private void Start()
        {
            CheckAllVolume();
            PlayBGM();
        }

        private void Update()
        {
            BGMCheck();
        }

        private void PlayBGM()
        {
            //_bgmSource.Play();
            _isPlayerBGM = true;
            _nowBGMIndex = 0;
        }

        private void StopBGM()
        {
            //_bgmSource.Stop();
            _isPlayerBGM = false;
            _bgmSource.Stop();
        }

        private void BGMCheck()
        {
            if (!_isPlayerBGM) return;
            //現在のBGMが終わったら次のBGMを再生
            if (!_bgmSource.isPlaying)
            {
                _nowBGMIndex++;
                if (_nowBGMIndex >= _audioClips.Count)
                {
                    _nowBGMIndex = 0;
                }
                _bgmSource.clip = _audioClips[_nowBGMIndex];
                _bgmSource.Play();
            }
        }

        /// <summary>
        /// マスターボリュームの音量設定
        /// </summary>
        /// <param name="volume">設定する音量 (0～1)</param>
        public void SetMasterVolume(float volume)
        {
            volume = Mathf.Clamp01(volume);
            _optionSO.MasterVolume = volume;

            float vol = (volume * 100f) - 80f;
            SetVolume("Master", vol);
        }

        /// <summary>
        /// BGMボリュームの音量設定
        /// </summary>
        /// <param name="volume">設定する音量（0～1）</param>
        public void SetBGMVolume(float volume)
        {
            volume = Mathf.Clamp01(volume);
            _optionSO.BGMVolume = volume;

            float vol = (volume * 100f) - 80f;
            SetVolume("BGM", vol);
        }

        /// <summary>
        /// SEボリュームの音量設定
        /// </summary>
        /// <param name="volume">設定する音量（0～1）</param>
        public void SetSEVolume(float volume)
        {
            volume = Mathf.Clamp01(volume);
            _optionSO.SEVolume = volume;

            float vol = (volume * 100f) - 80f;
            SetVolume("SE", vol);
        }

        private void SetVolume(string paramName,float volume)
        {
            _audioMixer.SetFloat(paramName, volume);
        }

        private void CheckAllVolume()
        {
            SetMasterVolume(_optionSO.MasterVolume);
            SetBGMVolume(_optionSO.BGMVolume);
            SetSEVolume(_optionSO.SEVolume);
        }
}
