using System.Collections;
using System.Collections.Generic;
using ChangeGame.Input;
using UnityEngine;

namespace ChangeGame.Player
{
    public class PlayerIdleState : PlayerGroundState
    {
        public PlayerIdleState(PlayerController player, PlayerInfoSO infoSo, InputSO inputSo, Animator anim, string animName) : base(player, infoSo, inputSo, anim, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _player.Movement.Stop();
        }
    }
}
