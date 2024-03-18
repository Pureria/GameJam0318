using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChangeGame.Input
{
    [CreateAssetMenu(fileName = "InputSO", menuName = "ChangeGame/Input/InputSO")]
    public class InputSO : ScriptableObject
    {
        public Vector3 MoveInput;
        public bool Attack1Input;
        public bool RollInput;
        
        public float Attack1InputTime;
        public float RollInputTime;
    }
}
