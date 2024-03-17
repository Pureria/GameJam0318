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
            Vector2 input = context.ReadValue<Vector2>();
            Vector3 moveDirection = new Vector3(input.x, 0, input.y);
            _inputSO.MoveInput = moveDirection;
        }
    }
}
