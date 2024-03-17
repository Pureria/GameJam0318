using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChangeGame.Input
{
    [CreateAssetMenu(fileName = "InputSO", menuName = "ChangeGame/Input/InputSO")]
    public class InputSO : ScriptableObject
    {
        [FormerlySerializedAs("MoveDirection")] public Vector3 MoveInput;
    }
}
