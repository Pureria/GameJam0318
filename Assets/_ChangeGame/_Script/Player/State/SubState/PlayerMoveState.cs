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
                _stateMachine.ChangeState(_player.NormalAttack);
            }
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            
            //_player.Movement.Move(_inputSO.MoveDirection, _infoSO._moveSpeed);
            
            //カメラの位置を計算して移動
            Vector3 cameraForward = Vector3.Scale(UnityEngine.Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            Vector3 moveForward = cameraForward * _inputSO.MoveInput.z + UnityEngine.Camera.main.transform.right * _inputSO.MoveInput.x;
            _player.Movement.Move(moveForward, _infoSO.MoveSpeed);
        }
    }
}
