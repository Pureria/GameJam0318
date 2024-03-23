using System.Collections;
using System.Collections.Generic;
using ChangeGame.Input;
using State;
using UnityEngine;

namespace ChangeGame.Player
{
    public class PlayerAttackState : PlayerBaseState
    {
        protected float _exitTime;
        private float _setCoolTime;
        public PlayerAttackState(PlayerController player, PlayerInfoSO infoSo, InputSO inputSo, StateMachine stateMachine, Animator anim, string animName, float attackCoolTime) : base(player, infoSo, inputSo, stateMachine, anim, animName)
        {
            _setCoolTime = attackCoolTime;
            _exitTime = -attackCoolTime;
        }

        public override void Exit()
        {
            base.Exit();
            _exitTime = Time.time;
        }

        /// <summary>
        /// クールタイム中かどうか？
        /// </summary>
        /// <returns>TRUE：クールタイム中   FALSE：クールタイム終了</returns>
        public bool CheckCoolTime() { return _exitTime + _setCoolTime > Time.time; }

        /// <summary>
        /// 0~1の範囲で現在のクールタイムの割合を返す
        /// </summary>
        /// <returns>クールタイムの割合</returns>
        public float GetCoolTimeRate()
        {
            return Mathf.Clamp01((Time.time - _exitTime) / _setCoolTime);
        }
    }
}
