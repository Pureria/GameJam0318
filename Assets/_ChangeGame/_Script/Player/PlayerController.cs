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

        [SerializeField] private PlayerInterSO _interSO;
        [SerializeField] private InputSO _inputSO;
        [SerializeField] private Transform _checkGroundTran;
        [SerializeField] private float _checkGroundRadius;
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private Transform _magicSpawnTran;
        [SerializeField] private GameObject _changeSuperEffect;
        [SerializeField] private GameObject _changeNormalEffect;
        [SerializeField] private List<Transform> _superPlayerProps = new List<Transform>();

        [Header("Component")] 
        [SerializeField] private Animator _anim;

        private StateMachine _stateMachine;
        #region State
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerNormalAttack NormalAttackState { get; private set; }
        public PlayerRollState RolLState { get; private set; }
        public PlayerMagic1State Magic1State { get; private set; }
        public PlayerMagic2State Magic2State { get; private set; }
        public PlayerMagic3State Magic3State { get; private set; }
        #endregion

        private bool _isDead;
        private PCHelper _helper;
        
        private Movement _movementComp;
        private States _statesComp;
        private Damage _damasgeComp;
        
        public Core _core {get; private set;}
        public Movement MovementComp { get => _movementComp ?? _core.GetCoreComponent(ref _movementComp);}
        public States StatesComp { get => _statesComp ?? _core.GetCoreComponent(ref _statesComp);}
        public Damage DamageComp { get => _damasgeComp ?? _core.GetCoreComponent(ref _damasgeComp);}
        
        public bool GroundCheck => CheckGround();
        public bool IsSuperPlayer => _helper.IsSuperPlayer;

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
            Magic2State = new PlayerMagic2State(this, _infoSO, _inputSO, _stateMachine, _anim, "magic2");
            Magic3State = new PlayerMagic3State(this, _infoSO, _inputSO, _stateMachine, _anim, "magic3");

            _helper = new PCHelper(_infoSO.NormalModeTime, _infoSO.SuperModeTime);
            _isDead = false;
        }

        private void Start()
        {
            _stateMachine.Initialize(IdleState);
            _statesComp.Initialize(_infoSO.MaxHealth);
            
            foreach (Transform prop in _superPlayerProps)
            {
                _helper.AddProps(prop);
            }
            
            _interSO.MaxSuperModeTime = _infoSO.SuperModeTime;
            _interSO.MaxNormalModeTime = _infoSO.NormalModeTime;
            _interSO.MaxHealth = _infoSO.MaxHealth;
        }

        private void OnEnable()
        {
            StatesComp.OnDeadEvent += Dead;
            DamageComp.OnDamageEvent += Damage;
            
            _helper.OnChangeModeEvent += ChangeModePlaer;
        }

        private void OnDisable()
        {
            StatesComp.OnDeadEvent -= Dead;
            DamageComp.OnDamageEvent -= Damage;
            
            _helper.OnChangeModeEvent -= ChangeModePlaer;
        }

        private void Update()
        {
            if (_isDead) return;
            _stateMachine.LogicUpdate();
            
            _helper.Update();

            _interSO.IsSuperMode = IsSuperPlayer;
            _interSO.CurrentHealth = StatesComp.CurrentHealth;
            _interSO.NowModeTime = Time.time - _helper.ChangeModeTime;
        }
        
        private void FixedUpdate()
        {
            if (_isDead) return;
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
            GameObject magic = Instantiate(magicPrefab, _magicSpawnTran.position, Quaternion.LookRotation(dir));
            Vector3 eulerAngle = magic.transform.eulerAngles;
            eulerAngle.z = magicPrefab.transform.eulerAngles.z;
            magic.transform.eulerAngles = eulerAngle;
        }

        private void Dead()
        {
            Debug.Log("プレイヤー死亡");
            _isDead = true;
            _interSO.IsDead = true;
        }

        private void Damage()
        {
            
        }

        private void ChangeModePlaer()
        {
            if (_helper.IsSuperPlayer) _changeSuperEffect.SetActive(true);
            else _changeNormalEffect.SetActive(true);
        }
    }
}
