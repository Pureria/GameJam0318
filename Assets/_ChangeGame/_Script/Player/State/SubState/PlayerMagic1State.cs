using System.Collections;
using System.Collections.Generic;
using ChangeGame.Input;
using State;
using UnityEngine;

namespace ChangeGame.Player
{
    public class PlayerMagic1State : PlayerBaseState
    {
        public PlayerMagic1State(PlayerController player, PlayerInfoSO infoSo, InputSO inputSo, StateMachine stateMachine, Animator anim, string animName) : base(player, infoSo, inputSo, stateMachine, anim, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            _player.Movement.Stop();
            _player.InstantMagic(_infoSO.Magic1Prefab);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_animationFinished)
            {
                _stateMachine.ChangeState(_player.IdleState);
            }
        }
    }
}