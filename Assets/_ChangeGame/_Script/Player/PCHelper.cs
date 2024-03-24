using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ChangeGame.Player
{
    public class PCHelper
    {
        private List<Transform> _playerProps;
        private bool _isSuperPlayer;
        private bool _isPlayLowSE;
        private bool _isPlayHighSE;
        private float _normalPlayerInterval;
        private float _superPlayerInterval;
        private float _changeModeTime;
        private PlayerAudioSO _playerAudioSO;
        
        public float ChangeModeTime => _changeModeTime;
        public bool IsSuperPlayer => _isSuperPlayer;

        public Action OnChangeModeEvent;
        
        public PCHelper(float normalTime, float superTime, PlayerAudioSO audioSO)
        {
            _playerProps = new List<Transform>();
            _isSuperPlayer = false;
            _changeModeTime = Time.time;
            _normalPlayerInterval = normalTime;
            _superPlayerInterval = superTime;
            _playerAudioSO = audioSO;
            
            _isPlayHighSE = false;
            _isPlayLowSE = false;
        }

        public void AddProps(Transform prop)
        {
            //リストにないものなら追加する
            if (!_playerProps.Contains(prop))
            {
                _playerProps.Add(prop);
            }
        }
        
        public void RemoveProps(Transform prop)
        {
            //リストにあるものなら削除する
            if (_playerProps.Contains(prop))
            {
                _playerProps.Remove(prop);
            }
        }

        private void SetSuperPlayer(bool isSuper)
        {
            _isSuperPlayer = isSuper;
            
            //リストにあるもののアクティブを切り替える
            foreach (var prop in _playerProps)
            {
                prop.gameObject.SetActive(isSuper);
            }
            
            //ノーマルモードに切り替わった場合はその音を、スーパーモードに切り替わった場合はその音を出す
            if (isSuper) _playerAudioSO.PlayerModeSource.PlayOneShot(_playerAudioSO.ChangeSuperSE);
            else _playerAudioSO.PlayerModeSource.PlayOneShot(_playerAudioSO.ChangeNormalSE);
            _isPlayHighSE = false;
            _isPlayLowSE = false;
        }

        public void Update()
        {
            float checkTime = 0;
            if (_isSuperPlayer) checkTime = _superPlayerInterval;
            else checkTime = _normalPlayerInterval;

            if (_changeModeTime + checkTime <= Time.time)
            {
                _changeModeTime = Time.time;
                SetSuperPlayer(!_isSuperPlayer);

                OnChangeModeEvent?.Invoke();
            }

            //オーディオ関連
            if (!_isSuperPlayer) return;
            //_playerAudioSO.CountDownHighの時間よりも残り時間が少ない場合は再生する
            if (_playerAudioSO.CountDownHigh.length >= GetNowModeTime() && !_isPlayHighSE)
            {
                //_playerAudioSO.PlayerModeSource.PlayOneShot(_playerAudioSO.CountDownHigh);
                _playerAudioSO.PlayerModeSource.clip = _playerAudioSO.CountDownHigh;
                _playerAudioSO.PlayerModeSource.Play();
                _isPlayHighSE = true;
            }
            else if (_playerAudioSO.CountDownLow.length >= GetNowModeTime() && !_isPlayLowSE)
            {
                //_playerAudioSO.PlayerModeSource.PlayOneShot(_playerAudioSO.CountDownLow);
                _playerAudioSO.PlayerModeSource.clip = _playerAudioSO.CountDownLow;
                _playerAudioSO.PlayerModeSource.Play();
                _isPlayLowSE = true;
            }
        }

        /// <summary>
        /// 現在のモードの残り時間を減らす
        /// </summary>
        /// <param name="boostTime">減らす時間</param>
        public void SubNowModeTime(float boostTime)
        {
            _changeModeTime -= boostTime;
        }

        /// <summary>
        /// 現在のモードの残り時間の割合を返す
        /// </summary>
        /// <returns>残り時間の割合</returns>
        public float GetNowModeTimeRate()
        {
            float interval = 0;
            //現在のモードの残り時間の割合を返す
            if (_isSuperPlayer) interval = _superPlayerInterval;
            else interval = _normalPlayerInterval;
            return Mathf.Clamp01((Time.time - _changeModeTime) / interval);
        }

        /// <summary>
        /// 現在のモードの残り時間を返す
        /// </summary>
        /// <returns></returns>
        public float GetNowModeTime()
        {
            //現在のモードの残り時間を返す
            if (_isSuperPlayer) return _superPlayerInterval - (Time.time - _changeModeTime);
            else return _normalPlayerInterval - (Time.time - _changeModeTime);
        }
    }
}
