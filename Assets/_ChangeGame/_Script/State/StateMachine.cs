using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class StateMachine
    {
        private BaseState _currentState;
        private BaseState _oldState;
        private bool _canChangeState;

        public BaseState CurrentState => _currentState;
        public BaseState OldState => _oldState;

        public void Initialize(BaseState initState)
        {
            _currentState = initState;
            _oldState = initState;
            _canChangeState = true;
            
            _currentState.Enter();
        }

        public void LogicUpdate()
        {
            _currentState.LogicUpdate();
        }

        public void FixedUpdate()
        {
            _currentState.FixedUpdate();
        }

        public void ChangeState(BaseState newState)
        {
            if (!_canChangeState) return;
            
            _currentState.Exit();
            _oldState = _currentState;
            _currentState = newState;
            _currentState.Enter();
        }
        
        public void SetCanChangeState(bool canChange) => _canChangeState = canChange;
    }
}
