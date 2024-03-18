using System;
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
        [SerializeField] private float _inputTime = 0.2f;

        private void Update()
        {
            CheckAttack1Input();
        }

        public void OnMoveInput(InputAction.CallbackContext context)
        {
            Vector2 input = context.ReadValue<Vector2>();
            Vector3 moveDirection = new Vector3(input.x, 0, input.y);
            _inputSO.MoveInput = moveDirection;
        }

        public void OnAttack1Input(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _inputSO.Attack1Input = true;
                _inputSO.Attack1InputTime = _inputTime;
            }
        }

        private void CheckAttack1Input()
        {
            if (!_inputSO.Attack1Input) return;
            if (_inputSO.Attack1InputTime + _inputTime <= Time.time)
            {
                _inputSO.Attack1Input = false;
            }
        }
    }
}
