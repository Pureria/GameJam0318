using ChangeGame.Player;
using State;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ChangeGame.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _goal;

        private StateMachine _stateMachine;
        private NavMeshAgent _agent;
        public EnemyIdleState IdleState { get; private set; }
        public EnemyWalkState WalkState { get; private set; }
        

        private void Awake()
        {
            _stateMachine = new StateMachine();
            IdleState = new EnemyIdleState(this, _stateMachine, _animator, "Idle"); //Ç±Ç±Ç≈Controllerà¯êîÇ∆ÇµÇƒìnÇµÇƒÇ¢ÇÈ
            WalkState = new EnemyWalkState(this, _stateMachine, _animator, "Walk");
        
        }

        private void Start()
        {

            _agent = GetComponent<NavMeshAgent>();
            _agent.destination = _goal.position;
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

        public void Walk()
        {
            _agent.Stop(false);
            Debug.Log("ï‡Ç¢ÇƒÇ¢Ç‹Ç∑");
        }

        public void Stop()
        {
            _agent.velocity = Vector3.zero;
            _agent.Stop(true);
        }

    }

}
