using System;
using System.Collections;
using System.Collections.Generic;
using ChangeGame.Input;
using UnityEngine;
using CorePackage;
using State;

namespace ChangeGame.Player
{
    /// <summary>
    /// プレイヤー制御用スクリプト
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Info")] 
        [SerializeField] private PlayerInfoSO _infoSO;
        [SerializeField] private InputSO _inputSO;
        [SerializeField] private Transform _checkGroundTran;
        [SerializeField] private float _checkGroundRadius;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Transform _magicSpawnTran;

        [Header("Component")] 
        [SerializeField] private Animator _anim;

        private StateMachine _stateMachine;
        #region State
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerNormalAttack NormalAttackState { get; private set; }
        public PlayerRollState RolLState { get; private set; }
        public PlayerMagic1State Magic1State { get; private set; }
        #endregion
        
        private Movement _movementComp;
        private States _statesComp;
        private Damage _damasgeComp;
        
        public Core _core {get; private set;}
        public Movement MovementComp { get => _movementComp ?? _core.GetCoreComponent(ref _movementComp);}
        public States StatesComp { get => _statesComp ?? _core.GetCoreComponent(ref _statesComp);}
        public Damage DamageComp { get => _damasgeComp ?? _core.GetCoreComponent(ref _damasgeComp);}
        
        public bool GroundCheck => CheckGround();

        public Action OnDeadEvent;

        private void Awake()
        {
            _core = GetComponentInChildren<Core>();
            if(_core == null) Debug.LogError("Coreが存在しません。");
            _stateMachine = new StateMachine();
            IdleState = new PlayerIdleState(this, _infoSO, _inputSO, _stateMachine, _anim, "idle");
            MoveState = new PlayerMoveState(this, _infoSO, _inputSO, _stateMachine, _anim, "move");
            NormalAttackState = new PlayerNormalAttack(this, _infoSO, _inputSO, _stateMachine, _anim, "normalAttack");
            RolLState = new PlayerRollState(this, _infoSO, _inputSO, _stateMachine, _anim, "roll");
            Magic1State = new PlayerMagic1State(this, _infoSO, _inputSO, _stateMachine, _anim, "magic1");
        }

        private void Start()
        {
            _stateMachine.Initialize(IdleState);
            _statesComp.Initialize(_infoSO.MaxHealth);
        }

        private void OnEnable()
        {
            _statesComp.OnDeadEvent += Dead;
            _damasgeComp.OnDamageEvent += Damage;
        }

        private void OnDisable()
        {
            _statesComp.OnDeadEvent -= Dead;
            _damasgeComp.OnDamageEvent -= Damage;
        }

        private void Update()
        {
            _stateMachine.LogicUpdate();
        }
        
        private void FixedUpdate()
        {
            _stateMachine.FixedUpdate();
        }
        
        private void OnDrawGizmos()
        {
            // 地面チェック用のギズモ
            Gizmos.color = new Color(0, 255, 0, 0.5f);
            Gizmos.DrawSphere(_checkGroundTran.position, _checkGroundRadius);
        }

        /// <summary>
        /// 地面チェック
        /// </summary>
        /// <returns>TRUE : 地面についてる     FALSE : 空中にいる</returns>
        private bool CheckGround()
        {
            // 地面チェック
            return Physics.CheckSphere(_checkGroundTran.position, _checkGroundRadius, _groundLayer);
        }

        public void AnimationFinishTrigger()
        {
            _stateMachine.CurrentState.AnimationFinishTrigger();
        }

        public void InstantMagic(GameObject magicPrefab, Vector3 dir)
        {
            //魔法生成位置に魔法を生成
            //GameObject magic = Instantiate(magicPrefab, _magicSpawnTran.position, _magicSpawnTran.rotation);
            
            //魔法生成位置に魔法を生成して向きをプレイヤーが向いている方向にする
            GameObject magic = Instantiate(magicPrefab, _magicSpawnTran.position, Quaternion.LookRotation(dir));
            Vector3 eulerAngle = magic.transform.eulerAngles;
            eulerAngle.z = magicPrefab.transform.eulerAngles.z;
            magic.transform.eulerAngles = eulerAngle;
        }

        private void Dead()
        {
            OnDeadEvent?.Invoke();
        }

        private void Damage()
        {
            
        }
    }
}
