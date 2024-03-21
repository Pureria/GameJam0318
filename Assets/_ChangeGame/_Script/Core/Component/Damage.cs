using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

namespace CorePackage
{
    public class Damage : CoreComponent
    {
        private bool _isInvisible;
        
        private States _states;
        private Movement _movement;
        public Action OnDamageEvent;

        private void Start()
        {
            _core.GetCoreComponent(ref _states);
            _core.GetCoreComponent(ref _movement);
            //if(_states == null) Debug.LogWarning("StatesがCoreに存在しません。");
            //if(_movement == null) Debug.LogWarning("MovementがCoreに存在しません。");
            _isInvisible = false;
        }

        /// <summary>
        /// ノックバック無しのダメージ用関数
        /// </summary>
        /// <param name="damageAmount">ダメージ量</param>
        public void AddDamage(float damageAmount)
        {
            if (_isInvisible) return;
            
            //オブジェクトの名前とダメージ数をDebug.Logで表示
            Debug.Log($"{this.transform.root.name}に{damageAmount}ダメージ");
            
            _states.SubHealth(damageAmount);
            OnDamageEvent?.Invoke();
        }

        /// <summary>
        /// ノックバックアリのダメージ用関数
        /// </summary>
        /// <param name="damageAmount">ダメージ量</param>
        /// <param name="kbDir">飛ばす向き</param>
        /// <param name="kbPower">飛ばす力</param>
        public void AddDamage(float damageAmount, Vector3 kbDir, float kbPower)
        {
            if (_isInvisible) return;
            
            AddDamage(damageAmount);
            _movement.SetVelocity(kbDir.normalized * kbPower);
        }
        
        public void SetIsInvisible(bool invisible) => _isInvisible = invisible;
    }
}
