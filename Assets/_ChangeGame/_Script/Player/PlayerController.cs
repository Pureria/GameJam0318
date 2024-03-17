using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Player
{
    /// <summary>
    /// プレイヤー制御用スクリプト
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        [Header("Player Info")]
        [SerializeField] private Transform _checkGroundTran;
        [SerializeField] private float _checkGroundRadius;
        [SerializeField] private LayerMask _groundLayer;

        public bool GroundCheck => CheckGround();
        
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
