using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Enemy
{
    public class EnemyIdleState : EnemyBaseState
    {
        private float _bootUpTime = 1f;  //スポーンしてからWalkStateに遷移するまでの時間

        public EnemyIdleState(EnemyController controller, StateMachine stateMachine, Animator anim, string animName) : base(controller, stateMachine, anim, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _enemyController.Stop();

        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_enemyController.CanAttackPlayer())
            {
                _stateMachine.ChangeState(_enemyController.AttackState);
            }
            else if (_startTime + _bootUpTime < Time.time)
            {
                _stateMachine.ChangeState(_enemyController.WalkState);
            }  
        }

    }

}
