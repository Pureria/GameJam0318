using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Enemy
{
    public class EnemyBaseState : BaseState
    {
        protected EnemyController _enemy;

        public EnemyBaseState(EnemyController controller, StateMachine stateMachine, Animator anim, string animName) : base(stateMachine, anim, animName)
        {
            this._enemy = controller;
        }
    }

}
