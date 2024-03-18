using System.Collections;
using System.Collections.Generic;
using ChangeGame.Input;
using UnityEngine;
using State;

namespace ChangeGame.Player
{
    public class PlayerIdleState : PlayerGroundState
    {
        public PlayerIdleState(PlayerController player, PlayerInfoSO infoSo, InputSO inputSo,StateMachine stateMachine, Animator anim, string animName) : base(player, infoSo, inputSo,stateMachine, anim, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _player.Movement.Stop();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            
            if(_inputSO.MoveInput != Vector3.zero)
            {
                _stateMachine.ChangeState(_player.MoveState);
            }
            else if (_inputSO.Attack1Input)
            {
                _inputSO.Attack1Input = false;
                _stateMachine.ChangeState(_player.NormalAttack);
            }
        }
    }
}
