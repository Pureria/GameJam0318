using System.Collections;
using System.Collections.Generic;
using ChangeGame.Input;
using State;
using UnityEngine;

namespace ChangeGame.Player
{
    public class PlayerNormalAttack : PlayerGroundState
    {
        public PlayerNormalAttack(PlayerController player, PlayerInfoSO infoSo, InputSO inputSo, StateMachine stateMachine, Animator anim, string animName) : base(player, infoSo, inputSo, stateMachine, anim, animName)
        {
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_animationFinished)
            {
                Debug.Log("NormalAttack Finished!");
                _stateMachine.ChangeState(_player.IdleState);
            }
        }
    }
}
