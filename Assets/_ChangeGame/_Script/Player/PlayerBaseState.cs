using System.Collections;
using System.Collections.Generic;
using ChangeGame.Input;
using UnityEngine;
using State;

namespace ChangeGame.Player
{
    public class PlayerBaseState : BaseState
    {
        protected PlayerController _player;
        protected PlayerInfoSO _infoSO;
        protected InputSO _inputSO;
        
        public PlayerBaseState(PlayerController player, PlayerInfoSO infoSo, InputSO inputSo, Animator anim, string animName) : base(anim, animName)
        {
            this._player = player;
            this._infoSO = infoSo;
            this._inputSO = inputSo;
        }
    }
}
