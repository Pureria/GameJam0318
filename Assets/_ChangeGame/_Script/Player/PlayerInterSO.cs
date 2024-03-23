using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ChangeGame.Player
{
    [CreateAssetMenu(fileName = "PlayerInterSO", menuName = "ChangeGame/Player/PlayerInterSO")]
    public class PlayerInterSO : ScriptableObject
    {
        private bool _isDead;
        private bool _isSuperMode;
        private float _maxSuperModeTime;
        private float _maxNormalModeTime;
        private float nowModeTimeRateRate; //残り時間の割合を保持（0～1）
        private float _maxHealth;
        private float _currentHealth;
        
        //攻撃のクールタイムの割合を保持（0～1）
        private float _magic1CoolTimeRate;
        private float _magic2CoolTimeRate;
        private float _magic3CoolTimeRate;

        public Action OnDamageEvent;
        public Action OnDeadEvent;
        public bool IsDead {get => _isDead; set => _isDead = value;}
        public bool IsSuperMode {get => _isSuperMode; set => _isSuperMode = value;}
        public float MaxSuperModeTime {get => _maxSuperModeTime; set => _maxSuperModeTime = value;}
        public float MaxNormalModeTime {get => _maxNormalModeTime; set => _maxNormalModeTime = value;}
        public float NowModeTimeRate {get => nowModeTimeRateRate; set => nowModeTimeRateRate = value;}
        public float MaxHealth {get => _maxHealth; set => _maxHealth = value;}
        public float CurrentHealth {get => _currentHealth; set => _currentHealth = value;}
        public float Magic1CoolTimeRate {get => _magic1CoolTimeRate; set => _magic1CoolTimeRate = value;}
        public float Magic2CoolTimeRate {get => _magic2CoolTimeRate; set => _magic2CoolTimeRate = value;}
        public float Magic3CoolTimeRate {get => _magic3CoolTimeRate; set => _magic3CoolTimeRate = value;}
    }
}
