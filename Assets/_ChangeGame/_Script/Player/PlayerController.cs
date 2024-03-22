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
        [SerializeField] private GameObject _changeSuperEffect;
        [SerializeField] private GameObject _changeNormalEffect;
        [SerializeField] private List<Transform> _superPlayerProps = new List<Transform>();
        [SerializeField] private Vector3 _magicSpawnPoint;
        
        [Header("Component")] 
        [SerializeField] private Animator _anim;

        private StateMachine _stateMachine;
        #region State
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        public PlayerAvoidState RolLState { get; private set; }
        public PlayerMagic1State Magic1State { get; private set; }
        public PlayerMagic2State Magic2State { get; private set; }
        public PlayerMagic3State Magic3State { get; private set; }
        public PlayerDeadState DeadState { get; private set; }
        #endregion

        private bool _isDead;
        private PCHelper _helper;
        
        private Movement _movementComp;
        private States _statesComp;
        private Damage _damasgeComp;
        private ItemPick _itemPick;
        
        public Core _core {get; private set;}
        public Movement MovementComp { get => _movementComp ?? _core.GetCoreComponent(ref _movementComp);}
        public States StatesComp { get => _statesComp ?? _core.GetCoreComponent(ref _statesComp);}
        public Damage DamageComp { get => _damasgeComp ?? _core.GetCoreComponent(ref _damasgeComp);}
        public ItemPick ItemPickComp { get => _itemPick ?? _core.GetCoreComponent(ref _itemPick);}
        public bool IsSuperPlayer => _helper.IsSuperPlayer;

        private void Awake()
        {
            _core = GetComponentInChildren<Core>();
            if(_core == null) Debug.LogError("Coreが存在しません。");
            _stateMachine = new StateMachine();
            IdleState = new PlayerIdleState(this, _infoSO, _inputSO, _stateMachine, _anim, "idle");
            MoveState = new PlayerMoveState(this, _infoSO, _inputSO, _stateMachine, _anim, "move");
            RolLState = new PlayerAvoidState(this, _infoSO, _inputSO, _stateMachine, _anim, "roll");
            Magic1State = new PlayerMagic1State(this, _infoSO, _inputSO, _stateMachine, _anim, "magic1");
            Magic2State = new PlayerMagic2State(this, _infoSO, _inputSO, _stateMachine, _anim, "magic2");
            Magic3State = new PlayerMagic3State(this, _infoSO, _inputSO, _stateMachine, _anim, "magic3");
            DeadState = new PlayerDeadState(this, _infoSO, _inputSO, _stateMachine, _anim, "dead");
            
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
            ItemPickComp.OnPickUpEvent += ItemPick;
            
            _helper.OnChangeModeEvent += ChangeModePlaer;
        }

        private void OnDisable()
        {
            StatesComp.OnDeadEvent -= Dead;
            DamageComp.OnDamageEvent -= Damage;
            ItemPickComp.OnPickUpEvent -= ItemPick;
            
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
            
            _anim.SetBool("isSuperMode", IsSuperPlayer);
        }

        private void OnDrawGizmos()
        {
            Vector3 dir = Vector3.zero;
            if(Camera.main != null) dir = Vector3.Scale(UnityEngine.Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;
            //マジックの生成位置を表示
            Gizmos.color = new Color(0, 255, 0, 0.5f);
            Vector3 magicSpawnPoint = transform.position + dir * _magicSpawnPoint.z;
            magicSpawnPoint.y += _magicSpawnPoint.y;
            Gizmos.DrawSphere(magicSpawnPoint, 0.1f);
        }

        private void FixedUpdate()
        {
            if (_isDead) return;
            _stateMachine.FixedUpdate();
        }
        private void Dead()
        {
            _stateMachine.ChangeState(DeadState);
            _stateMachine.SetCanChangeState(false);
            _interSO.OnDeadEvent?.Invoke();
        }

        private void Damage()
        {
            _interSO.OnDamageEvent?.Invoke();
        }

        private void ItemPick()
        {
            //ノーマルモード時のみ残り時間を減少させる
            if (IsSuperPlayer) return;
            
            _helper.SubNowModeTime(_infoSO.ItemSubTime);
        }

        private void ChangeModePlaer()
        {
            if (_helper.IsSuperPlayer) _changeSuperEffect.SetActive(true);
            else _changeNormalEffect.SetActive(true);
        }

        public void AnimationFinishTrigger()
        {
            _stateMachine.CurrentState.AnimationFinishTrigger();
        }

        public void InstantMagic(GameObject magicPrefab, Vector3 dir)
        {
            Vector3 spawnPoint = transform.position + dir * _magicSpawnPoint.z;
            spawnPoint.y += _magicSpawnPoint.y;
            
            GameObject magic = Instantiate(magicPrefab, spawnPoint, Quaternion.LookRotation(dir));
            Vector3 eulerAngle = magic.transform.eulerAngles;
            eulerAngle.z = magicPrefab.transform.eulerAngles.z;
            magic.transform.eulerAngles = eulerAngle;
        }

        /// <summary>
        /// プレイヤーの死亡アニメーションが終了したら呼ばれる
        /// </summary>
        public void CallPlayerDead()
        {
            Debug.Log("プレイヤー死亡");
            _interSO.IsDead = true;
            _isDead = true;
        }
    }
}
