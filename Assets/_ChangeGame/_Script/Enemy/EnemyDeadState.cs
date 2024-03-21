using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Enemy
{
    public class EnemyDeadState : EnemyBaseState
    {
        public EnemyDeadState(EnemyController controller, StateMachine stateMachine, Animator anim, string animName) : base(controller, stateMachine, anim, animName)
        {
        }

        public override void Enter()
        {
            base.Enter();
            
            _enemyController.Stop();
            _anim.SetTrigger(_animName + "T");
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (_animationFinished)
            {
                Debug.Log("Enemy‚ÍŽ€‚É‚Ü‚µ‚½");
                _enemyController.SetActiveFalse();
            }
        }

    }

}
