using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Enemy
{
    public class EnemyWalkState : EnemyBaseState
    {
        public EnemyWalkState(EnemyController controller, StateMachine stateMachine, Animator anim, string animName) : base(controller, stateMachine, anim, animName)
        {
        }

        public override void FixedUpdate()
        {
            base.FixedUpdate();
            _enemyController.Walk();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_enemyController.CanAttackPlayer())
            {
                _stateMachine.ChangeState(_enemyController.AttackState);
            }
        }

    }

}
