using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Enemy
{
    public class EnemyAttackState : EnemyBaseState
    {
        private float damageAmount = 50;    //çUåÇÇÃÉ_ÉÅÅ[ÉWó 

        public EnemyAttackState(EnemyController controller, StateMachine stateMachine, Animator anim, string animName) : base(controller, stateMachine, anim, animName)
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
            
            /*
            if (_startTime + 1f < Time.time)
            {
                _stateMachine.ChangeState(_enemyController.IdleState);
            }
            */

            if (_animationFinished)
            {
                _stateMachine.ChangeState(_enemyController.IdleState);
            }
        }
        
        public override void AnimationFirstTrigger()
        {
            base.AnimationFirstTrigger();
            
            _enemyController.Attack(damageAmount);
            Debug.Log("EnemyÇ™çUåÇÇµÇΩ");
        }
    }

}
