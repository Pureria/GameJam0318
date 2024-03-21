using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Enemy
{
    public class EnemyDamageState : EnemyBaseState
    {
        public EnemyDamageState(EnemyController controller, StateMachine stateMachine, Animator anim, string animName) : base(controller, stateMachine, anim, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            _enemyController.Stop();
            Debug.Log("Enemy‚ªUŒ‚‚ğó‚¯‚½");
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();
            if (_animationFinished)
            {
                _stateMachine.ChangeState(_enemyController.IdleState);
            }
        }


    }

}
