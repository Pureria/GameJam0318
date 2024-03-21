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
        [SerializeField] private float MaxHP;

        private State.StateMachine _stateMachine;
        private NavMeshAgent _agent;
        private States _statesComp;
        private Damage _damageComp;


        public EnemyIdleState IdleState { get; private set; }
        public EnemyWalkState WalkState { get; private set; }
        public EnemyAttackState AttackState { get; private set; }
        public EnemyDamageState DamageState { get; private set; }
        public Core _core { get; private set; }
        public States StatesComp { get => _statesComp ?? _core.GetCoreComponent(ref _statesComp); }
        public Damage DamageComp { get => _damageComp ?? _core.GetCoreComponent(ref _damageComp); }

        private void Awake()
        {
            _stateMachine = new State.StateMachine();
            IdleState = new EnemyIdleState(this, _stateMachine, _animator, "Idle"); //������Controller�����Ƃ��ēn���Ă���
            WalkState = new EnemyWalkState(this, _stateMachine, _animator, "Walk");
            AttackState = new EnemyAttackState(this, _stateMachine, _animator, "Attack");
            _core = GetComponentInChildren<Core>();
            
        }

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.destination = _goal.position;
            _stateMachine.Initialize(IdleState);
            StatesComp.Initialize(MaxHP);

        }

        private void OnEnable()
        {
            DamageComp.OnDamageEvent += Damage;
            StatesComp.OnDeadEvent += Dead;
        }

        private void OnDisable()
        {
            DamageComp.OnDamageEvent -= Damage;
            StatesComp.OnDeadEvent -= Dead;
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
            Debug.Log("Enemy�������Ă��܂�");
        }

        public void Stop()
        {        
            //_agent�̈ړ����X�g�b�v������
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
            //�~��`��
            Gizmos.color = new Color(255, 0, 0, 0.5f);
            Gizmos.DrawSphere(_checkAttackPosition.position, _checkAttackRadius);
        }

        private void Dead()
        {
            this.gameObject.SetActive(false);
        }

        private void Damage()
        {

        }

    }

}
