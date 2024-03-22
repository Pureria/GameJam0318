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
        protected float _setCoolTime;
        public PlayerAttackState(PlayerController player, PlayerInfoSO infoSo, InputSO inputSo, StateMachine stateMachine, Animator anim, string animName, float attackCoolTime) : base(player, infoSo, inputSo, stateMachine, anim, animName)
        {
        }

        public override void Enter()
        {
            if(_exitTime)
            
            base.Enter();
        }

        public override void Exit()
        {
            base.Exit();
            _exitTime = Time.time;
        }
    }
}
