using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class BaseState
    {
        protected bool _animationFinished;
        protected bool _endState;
        protected float _startTime;
        protected Animator _anim;

        private string _animName;

        public bool EndState => _endState;
        
        public BaseState(Animator anim, string animName)
        {
            _anim = anim;
            _animName = animName;
        }
        
        public virtual void Enter()
        {
            _anim.SetBool(_animName, true);
            
            _animationFinished = false;
            _startTime = Time.time;
            _endState = false;
        }

        public virtual void Exit()
        {
            _anim.SetBool(_animName, false);
            _endState = true;
        }

        public virtual void LogicUpdate()
        {
            
        }

        public virtual void FixedUpdate()
        {
            
        }

        public virtual void AnimationFirstTrigger()
        {
            
        }

        public virtual void AnimationSecondTrigger()
        {
            
        }

        public void AnimationFinishTrigger() => _animationFinished = true;
    }
}
