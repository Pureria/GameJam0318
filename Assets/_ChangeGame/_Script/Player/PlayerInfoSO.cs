using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChangeGame.Player
{
    [CreateAssetMenu(fileName = "PlayerInfoSO", menuName = "ChangeGame/Player/PlayerInfoSO")]
    public class PlayerInfoSO : ScriptableObject
    {
        [FormerlySerializedAs("_moveSpeed")] public float MoveSpeed = 5.0f;

        [Header("Magic Prefabs")] 
        public GameObject Magic1Prefab;
    }
}
