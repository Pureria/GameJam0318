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
            _player.MovementComp.Stop();
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
                _stateMachine.ChangeState(_player.NormalAttackState);
            }
            else if (_inputSO.RollInput)
            {
                _inputSO.RollInput = false;
                _stateMachine.ChangeState(_player.RolLState);
            }
            else if (_inputSO.Attack2Input)
            {
                _inputSO.Attack2Input = false;
                _stateMachine.ChangeState(_player.Magic1State);
            }
            else if (_inputSO.Attack3Input)
            {
                _inputSO.Attack3Input = false;
                _stateMachine.ChangeState(_player.Magic2State);
            }
            else if (_inputSO.Attack4Input)
            {
                _inputSO.Attack4Input = false;
                _stateMachine.ChangeState(_player.Magic3State);
            }
        }
    }
}
