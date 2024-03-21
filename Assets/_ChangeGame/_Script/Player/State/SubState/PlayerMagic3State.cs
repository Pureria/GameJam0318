using System.Collections;
using System.Collections.Generic;
using ChangeGame.Input;
using State;
using UnityEngine;

namespace ChangeGame.Player
{
    public class PlayerMagic3State : PlayerBaseState
    {
        private Vector3 cameraForward;
        
        public PlayerMagic3State(PlayerController player, PlayerInfoSO infoSo, InputSO inputSo, StateMachine stateMachine, Animator anim, string animName) : base(player, infoSo, inputSo, stateMachine, anim, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            cameraForward = Vector3.Scale(UnityEngine.Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            
            _player.MovementComp.Stop();
            _player.InstantMagic(_infoSO.Magic3Prefab,cameraForward);
        }
        
        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_animationFinished)
            {
                _stateMachine.ChangeState(_player.IdleState);
            }
            
            Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
            targetRotation.x = 0;
            targetRotation.z = 0;
            _player.transform.rotation = Quaternion.Slerp(_player.transform.rotation, targetRotation, Time.deltaTime * 10f); // 滑らかな回転
        }
    }
}
