using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks.Triggers;
using UnityEngine;

namespace CorePackage
{
    public class Damage : CoreComponent
    {
        private States _states;
        private Movement _movement;
        public Action OnDamageEvent;

        private void Start()
        {
            _core.GetCoreComponent(ref _states);
            _core.GetCoreComponent(ref _movement);
            //if(_states == null) Debug.LogWarning("StatesがCoreに存在しません。");
            //if(_movement == null) Debug.LogWarning("MovementがCoreに存在しません。");
        }

        /// <summary>
        /// ノックバック無しのダメージ用関数
        /// </summary>
        /// <param name="damageAmount">ダメージ量</param>
        public void AddDamage(float damageAmount)
        {
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
            AddDamage(damageAmount);
            _movement.SetVelocity(kbDir.normalized * kbPower);
        }
    }
}
