using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace CorePackage
{
    public class States : CoreComponent
    {
        private bool _isInitialize;
        private bool _isDead;
        private float _maxHealth;
        private float _currentHealth;
        
        public Action OnDeadEvent;

        public float MaxHealth => _maxHealth;
        public float CurrentHealth => _currentHealth;
        public bool IsDead => _isDead;

        protected override void Awake()
        {
            base.Awake();
            _isInitialize = false;
        }
        
        public void Initialize(float maxHealth)
        {
            _isInitialize = true;
            _isDead = false;
            _maxHealth = maxHealth;
            _currentHealth = _maxHealth;
        }

        public void AddHealth(float addAmount)
        {
            if (!_isInitialize)
            {
                Debug.LogWarning("Statesが初期化されていません。");
                return;
            }
            
            _currentHealth += addAmount;
            if(_currentHealth > _maxHealth) _currentHealth = _maxHealth;
        }

        public void SubHealth(float subAmount)
        {
            if (_isDead) return;
            if (!_isInitialize)
            {
                Debug.LogWarning("Statesが初期化されていません。");
                return;
            }
            
            _currentHealth -= subAmount;
            if(_currentHealth <= 0)
            {
                _currentHealth = 0;
                _isDead = true;
                OnDeadEvent?.Invoke();
            }
        }
    }
}
