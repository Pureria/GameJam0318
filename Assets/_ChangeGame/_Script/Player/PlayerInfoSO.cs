using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Player
{
    [CreateAssetMenu(fileName = "PlayerInfoSO", menuName = "ChangeGame/Player/PlayerInfoSO")]
    public class PlayerInfoSO : ScriptableObject
    {
        public float _moveSpeed = 5.0f;
    }
}
