using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ChangeGame.Input
{
    public class PlayerInput : MonoBehaviour
    {
        [SerializeField] private InputSO _inputSO;
        
        public void OnMoveInput(InputAction.CallbackContext context)
        {
            Vector3 moveDirection = context.ReadValue<Vector3>();
            _inputSO.MoveDirection = moveDirection;
        }
    }
}
