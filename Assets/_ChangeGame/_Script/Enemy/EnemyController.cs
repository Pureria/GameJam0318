using ChangeGame.Player;
using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private StateMachine _stateMachine;
        public EnemyIdleState IdleState { get; private set; }
        

        private void Awake()
        {
            _stateMachine = new StateMachine();
            IdleState = new EnemyIdleState(this, _stateMachine, _animator, "idle");
        }

        private void Start()
        {
            _stateMachine.Initialize(IdleState);
        }

        private void Update()
        {
            _stateMachine.LogicUpdate();
            
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }

    }

}
