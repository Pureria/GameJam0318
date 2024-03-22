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
        private float _normalPlayerInterval;
        private float _superPlayerInterval;
        private float _changeModeTime;

        public float ChangeModeTime => _changeModeTime;
        public bool IsSuperPlayer => _isSuperPlayer;

        public Action OnChangeModeEvent;
        
        public PCHelper(float normalTime, float superTime)
        {
            _playerProps = new List<Transform>();
            _isSuperPlayer = false;
            _changeModeTime = Time.time;
            _normalPlayerInterval = normalTime;
            _superPlayerInterval = superTime;
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
        }

        /// <summary>
        /// 現在のモードの残り時間を減らす
        /// </summary>
        /// <param name="boostTime">減らす時間</param>
        public void SubNowModeTime(float boostTime)
        {
            _changeModeTime -= boostTime;
        }
    }
}
