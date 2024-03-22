using System.Collections;
using System.Collections.Generic;
using ChangeGame.Input;
using ChangeGame.Player;
using State;
using UnityEngine;

namespace ChangeGame.Player
{
    public class PlayerAvoidState : PlayerBaseState
    {
        public PlayerAvoidState(PlayerController player, PlayerInfoSO infoSo, InputSO inputSo, StateMachine stateMachine, Animator anim, string animName) : base(player, infoSo, inputSo, stateMachine, anim, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            _player.DamageComp.SetIsInvisible(true);
        }

        public override void Exit()
        {
            base.Exit();

            _player.DamageComp.SetIsInvisible(false);
        }

        public override void LogicUpdate()
        {
            if (_animationFinished)
            {
                _stateMachine.ChangeState(_player.IdleState);
            }
        }
    }
}
