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
            CheckAttack2Input();
            CheckRollInput();
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
                _inputSO.Attack1InputTime = Time.time;
            }
        }
        
        public void OnAttack2Input(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _inputSO.Attack2Input = true;
                _inputSO.Attack2InputTime = Time.time;
            }
        }

        public void OnRollInput(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _inputSO.RollInput = true;
                _inputSO.RollInputTime = Time.time;
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

        private void CheckRollInput()
        {
            if (!_inputSO.RollInput) return;
            if (_inputSO.RollInputTime + _inputTime <= Time.time)
            {
                _inputSO.RollInput = false;
            }
        }

        private void CheckAttack2Input()
        {
            if (!_inputSO.Attack2Input) return;
            if (_inputSO.Attack2InputTime + _inputTime <= Time.time)
            {
                _inputSO.Attack2Input = false;
            }
        }
    }
}
