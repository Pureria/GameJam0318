using ChangeGame.Player;
using CorePackage;
using State;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

namespace ChangeGame.Enemy
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _goal;
        [SerializeField] private Transform _checkAttackPosition;
        [SerializeField] private float _checkAttackRadius;

        private State.StateMachine _stateMachine;
        private NavMeshAgent _agent;
        public EnemyIdleState IdleState { get; private set; }
        public EnemyWalkState WalkState { get; private set; }
        public EnemyAttackState AttackState { get; private set; }
        

        private void Awake()
        {
            _stateMachine = new State.StateMachine();
            IdleState = new EnemyIdleState(this, _stateMachine, _animator, "Idle"); //Ç±Ç±Ç≈Controllerà¯êîÇ∆ÇµÇƒìnÇµÇƒÇ¢ÇÈ
            WalkState = new EnemyWalkState(this, _stateMachine, _animator, "Walk");
            AttackState = new EnemyAttackState(this, _stateMachine, _animator, "Attack");
            
            
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
            
            _agent.destination = _goal.position;
        }

        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }

        public void Walk()
        {
            _agent.isStopped = false;
            Debug.Log("ï‡Ç¢ÇƒÇ¢Ç‹Ç∑");
        }

        public void Stop()
        {        
            //_agentÇÃà⁄ìÆÇÉXÉgÉbÉvÇµÇΩÇ¢
            _agent.isStopped = true;
        }

        public bool CanAttackPlayer()
        {
            Collider[] hitColliders = Physics.OverlapSphere(_checkAttackPosition.position, _checkAttackRadius);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.tag == "Player")
                {
                    return true;
                }
            }
            return false;
        }


        public void Attack(float damageAmount)
        {
            Collider[] hitColliders = Physics.OverlapSphere(_checkAttackPosition.position, _checkAttackRadius);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.tag != "Player") continue;
                Core tCore = hitCollider.gameObject.GetComponentInChildren<Core>();
                if (tCore == null) continue;
                if (tCore.GetCoreComponentBool(out Damage damage))
                {
                    damage.AddDamage(damageAmount);
                }
            }
        }

        public void AnimationFinishTrigger()
        {
            _stateMachine.CurrentState.AnimationFinishTrigger();
        }

        public void AnimationFirstTrigger()
        {
            _stateMachine.CurrentState.AnimationFirstTrigger();
        }
        
        private void OnDrawGizmos()
        {
            //â~Çï`âÊ
            Gizmos.color = new Color(255, 0, 0, 0.5f);
            Gizmos.DrawSphere(_checkAttackPosition.position, _checkAttackRadius);
        }

    }

}
