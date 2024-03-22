using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChangeGame.Player
{
    [CreateAssetMenu(fileName = "PlayerInfoSO", menuName = "ChangeGame/Player/PlayerInfoSO")]
    public class PlayerInfoSO : ScriptableObject
    {
        [Header("Player Info")]
        public float MaxHealth = 100.0f;
        public float MoveSpeed = 5.0f;
        [Tooltip("ノーマルモードの継続時間")]public float NormalModeTime = 30.0f;
        [Tooltip("スーパーモードの継続時間")]public float SuperModeTime = 30.0f;
        [Tooltip("アイテムをとった時に減少する時間")] public float ItemSubTime = 4.0f;

        [Header("Magic Prefabs")] 
        public GameObject Magic1Prefab;

        public GameObject Magic2Prefab;
        public GameObject Magic3Prefab;

        [Header("Magic Info")] 
        [Tooltip("スラッシュ攻撃のクールタイム")]public float Magic1CoolTime = 1.0f;
        [Tooltip("爆弾攻撃のクールタイム")]public float Magic2CoolTime = 1.0f;
        [Tooltip("ビームのクールタイム")]public float Magic3CoolTime = 1.0f;
    }
}
