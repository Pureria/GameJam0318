using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ChangeGame.Input
{
    [CreateAssetMenu(fileName = "InputSO", menuName = "ChangeGame/Input/InputSO")]
    public class InputSO : ScriptableObject
    {
        public Vector3 MoveDirection;
    }
}
