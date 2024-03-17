using System.Collections;
using System.Collections.Generic;
using ChangeGame.Input;
using UnityEngine;

namespace ChangeGame.Player
{
    public class PlayerGroundState : PlayerBaseState
    {
        public PlayerGroundState(PlayerController player, PlayerInfoSO infoSo, InputSO inputSo, Animator anim, string animName) : base(player, infoSo, inputSo, anim, animName)
        {
        }
    }
}
