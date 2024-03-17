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

        [Header("Component")] 
        [SerializeField] private Animator _anim;

        private StateMachine _stateMachine;
        #region State
        public PlayerIdleState IdleState { get; private set; }
        public PlayerMoveState MoveState { get; private set; }
        #endregion
        
        private Movement _movement;
        
        public Core _core {get; private set;}
        public Movement Movement { get => _movement ?? _core.GetCoreComponent(ref _movement);}
        
        public bool GroundCheck => CheckGround();

        private void Awake()
        {
            _core = GetComponentInChildren<Core>();
            if(_core == null) Debug.LogError("Coreが存在しません。");
            _stateMachine = new StateMachine();
            IdleState = new PlayerIdleState(this, _infoSO, _inputSO, _stateMachine, _anim, "idle");
            MoveState = new PlayerMoveState(this, _infoSO, _inputSO, _stateMachine, _anim, "move");
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
    }
}
