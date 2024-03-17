using System.Collections;
using System.Collections.Generic;
using ChangeGame.Input;
using UnityEngine;
using State;

namespace ChangeGame.Player
{
    public class PlayerGroundState : PlayerBaseState
    {
        public PlayerGroundState(PlayerController player, PlayerInfoSO infoSo, InputSO inputSo,StateMachine stateMachine, Animator anim, string animName) : base(player, infoSo, inputSo,stateMachine, anim, animName)
        {
        }
    }
}
