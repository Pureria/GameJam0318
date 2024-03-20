using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Enemy
{
    public class EnemyIdleState : EnemyBaseState
    {
        public EnemyIdleState(EnemyController controller, StateMachine stateMachine, Animator anim, string animName) : base(controller, stateMachine, anim, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();

        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_startTime + 1f < Time.time)
            {
                _stateMachine.ChangeState(_enemyController.WalkState);
            }
        }

    }

}
