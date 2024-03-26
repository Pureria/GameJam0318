using System;
using System.Collections;
using System.Collections.Generic;
using ChangeGame.AudioSpectrum;
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
        
        [Header("OptionSOの初期値")]
        [SerializeField] private float _masterVolume = 0.8f;
        [SerializeField] private float _bgmVolume = 0.5f;
        [SerializeField] private float _seVolume = 0.6f;
        [SerializeField] private float _mouseSensivity = 0f;

        private bool _isPlayerBGM;
        private int _nowBGMIndex;
        private GetAudioData _getAudioData;
        
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }

        private void OnEnable()
        {
            _optionSO.OnChangeAnyVolumeEvent += CheckAllVolume;
            
            //PlayerPrefsからoptionSOの値が存在するかを確認し無かったら初期値を代入
            if (!PlayerPrefs.HasKey("MasterVolume")) _optionSO.MasterVolume = _masterVolume;
            else _optionSO.MasterVolume = PlayerPrefs.GetFloat("MasterVolume");
            //残りの3つのデータも同じように処理する
            if (!PlayerPrefs.HasKey("BGMVolume")) _optionSO.BGMVolume = _bgmVolume;
            else _optionSO.BGMVolume = PlayerPrefs.GetFloat("BGMVolume");
            if (!PlayerPrefs.HasKey("SEVolume")) _optionSO.SEVolume = _seVolume;
            else _optionSO.SEVolume = PlayerPrefs.GetFloat("SEVolume");
            if (!PlayerPrefs.HasKey("MouseXSensivity")) _optionSO.MouseXSensivity = _mouseSensivity;
            else _optionSO.MouseXSensivity = PlayerPrefs.GetFloat("MouseXSensivity");
            if(!PlayerPrefs.HasKey("MouseYSensivity")) _optionSO.MouseYSensivity = _mouseSensivity;
            else _optionSO.MouseYSensivity = PlayerPrefs.GetFloat("MouseYSensivity");
        }

        private void OnDisable()
        {
            _optionSO.OnChangeAnyVolumeEvent -= CheckAllVolume;
            
            //optionSOの値をPlayerPrefsに保存
            PlayerPrefs.SetFloat("MasterVolume", _optionSO.MasterVolume);
            PlayerPrefs.SetFloat("BGMVolume", _optionSO.BGMVolume);
            PlayerPrefs.SetFloat("SEVolume", _optionSO.SEVolume);
            PlayerPrefs.SetFloat("MouseSensivity", _optionSO.MouseXSensivity);
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
