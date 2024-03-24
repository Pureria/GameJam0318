using System.Collections;
using System.Collections.Generic;
using ChangeGame.Player;
using UnityEngine;
using UnityEngine.UI;

namespace ChangeGame.UI
{
    public class PlayerUI : MonoBehaviour
    {
        [SerializeField] private PlayerInterSO _playerInterSo;

        [Header("各UIのオブジェクト")] 
        [SerializeField] private Image _hpUI;
        [SerializeField] private Image _nowModeTimeUI;
        [SerializeField] private Image _TopLaserUI;
        [SerializeField] private Image _LeftBombUI;
        [SerializeField] private Image _RightSlashUI;

        private void Update()
        {
            float hp = Mathf.Clamp01(_playerInterSo.CurrentHealth / _playerInterSo.MaxHealth);
            _hpUI.fillAmount = hp;
            if (_playerInterSo.IsSuperMode)
            {
                _nowModeTimeUI.fillAmount = 1 - _playerInterSo.NowModeTimeRate;
                _TopLaserUI.fillAmount = _playerInterSo.Magic3CoolTimeRate;
                _LeftBombUI.fillAmount = _playerInterSo.Magic2CoolTimeRate;
                _RightSlashUI.fillAmount = _playerInterSo.Magic1CoolTimeRate;
            }
            else
            {
                _nowModeTimeUI.fillAmount = _playerInterSo.NowModeTimeRate;
                _TopLaserUI.fillAmount = 0;
                _LeftBombUI.fillAmount = 0;
                _RightSlashUI.fillAmount = 0;
            }
        }
    }
}
