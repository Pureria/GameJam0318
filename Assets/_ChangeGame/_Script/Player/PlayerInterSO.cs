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
        private float _nowModeTime; //現在のモードの経過時間
        private float _maxHealth;
        private float _currentHealth;

        public Action OnDamageEvent;
        public Action OnDeadEvent;
        public bool IsDead {get => _isDead; set => _isDead = value;}
        public bool IsSuperMode {get => _isSuperMode; set => _isSuperMode = value;}
        public float MaxSuperModeTime {get => _maxSuperModeTime; set => _maxSuperModeTime = value;}
        public float MaxNormalModeTime {get => _maxNormalModeTime; set => _maxNormalModeTime = value;}
        public float NowModeTime {get => _nowModeTime; set => _nowModeTime = value;}
        public float MaxHealth {get => _maxHealth; set => _maxHealth = value;}
        public float CurrentHealth {get => _currentHealth; set => _currentHealth = value;}
    }
}
