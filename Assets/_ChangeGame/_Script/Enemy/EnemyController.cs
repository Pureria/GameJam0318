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
        [SerializeField] private float _bootUpTime;

        private StateMachine _stateMachine;
        private NavMeshAgent _agent;
        public EnemyIdleState IdleState { get; private set; }
        public EnemyWalkState WalkState { get; private set; }
        

        private void Awake()
        {
            _stateMachine = new StateMachine();
            IdleState = new EnemyIdleState(this, _stateMachine, _animator, "Idle"); //ここでController引数として渡している
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
            _agent.isStopped = false;
            Debug.Log("歩いています");
        }

        public void Stop()
        {        
            //_agentの移動をストップしたい
            _agent.isStopped = true;
        }

    }

}
