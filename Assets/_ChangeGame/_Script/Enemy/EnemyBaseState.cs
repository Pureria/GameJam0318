using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Enemy
{
    public class EnemyBaseState : BaseState
    {
        protected EnemyController _enemyController;
        protected string _animName;


        public EnemyBaseState(EnemyController controller, StateMachine stateMachine, Animator anim, string animName) : base(stateMachine, anim, animName)
        {
            this._enemyController = controller;
            _animName = animName;
        }
    }

}
