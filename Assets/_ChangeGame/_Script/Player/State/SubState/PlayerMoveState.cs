using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChangeGame.Input;
using State;

namespace ChangeGame.Player
{
    public class PlayerMoveState : PlayerBaseState
    {
        public PlayerMoveState(PlayerController player, PlayerInfoSO infoSo, InputSO inputSo,StateMachine stateMachine, Animator anim, string animName) : base(player, infoSo, inputSo, stateMachine,anim, animName)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_inputSO.MoveInput == Vector3.zero)
            {
                _stateMachine.ChangeState(_player.IdleState);
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
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            
            //_player.Movement.Move(_inputSO.MoveDirection, _infoSO._moveSpeed);
            
            //カメラの位置を計算して移動
            Vector3 cameraForward = Vector3.Scale(UnityEngine.Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 moveForward = cameraForward * _inputSO.MoveInput.z + UnityEngine.Camera.main.transform.right * _inputSO.MoveInput.x;
            _player.MovementComp.Move(moveForward, _infoSO.MoveSpeed);
        }
    }
}
