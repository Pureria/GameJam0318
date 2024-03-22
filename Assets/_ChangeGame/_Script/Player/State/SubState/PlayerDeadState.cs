using System.Collections;
using System.Collections.Generic;
using ChangeGame.Input;
using State;
using UnityEngine;

namespace ChangeGame.Player
{
    public class PlayerDeadState : PlayerBaseState
    {
        private bool _isCallDeadEvent;
        
        public PlayerDeadState(PlayerController player, PlayerInfoSO infoSo, InputSO inputSo, StateMachine stateMachine, Animator anim, string animName) : base(player, infoSo, inputSo, stateMachine, anim, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _isCallDeadEvent = false;
            _anim.SetTrigger("deadT");
        }

        public override void LogicUpdate()
        {
            if(_animationFinished && !_isCallDeadEvent)
            {
                _isCallDeadEvent = true;
                _player.CallPlayerDead();
            }
        }
    }
}
