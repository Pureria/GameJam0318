using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Enemy
{
    public class EnemyAttackState : EnemyBaseState
    {
        private float damageAmount = 50;    //UŒ‚‚Ìƒ_ƒ[ƒW—Ê

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

            if (_animationFinished)
            {
                _stateMachine.ChangeState(_enemyController.IdleState);
            }
        }
        
        public override void AnimationFirstTrigger()
        {
            base.AnimationFirstTrigger();
            
            _enemyController.Attack(damageAmount);
            Debug.Log("Enemy‚ªUŒ‚‚µ‚½");
        }
    }

}
