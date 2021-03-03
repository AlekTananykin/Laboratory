using Assets.Code.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    public sealed class PlayerMoveSystem
    {

        public readonly float _speed;
        private const float _gravity = -9.8f;
        private readonly float _jumpSpeed;

        private float _vertSpeed = 0;

        private IPlayerMoveInput _playerMoveInput;

        public PlayerMoveSystem(float speed, float jumpSpeed)
        {
            _playerMoveInput = new PlayerKeyboardInput();
            _vertSpeed = 0;
            _speed = speed;
            _jumpSpeed = jumpSpeed;
        }

        public Vector3 Update(bool isGrounded)
        {
            float deltaX = _playerMoveInput.HorizontalMove * _speed;
            float deltaZ = _playerMoveInput.VerticalMove * _speed;
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, _speed);
            movement *= Time.deltaTime;

            movement = ProcessVerticalMove(movement, isGrounded);

            return movement;
            //movement = transform.TransformDirection(movement);
            //_charController.Move(movement);
        }

        private Vector3 ProcessVerticalMove(Vector3 movement, bool isGrounded)
        {
            if (isGrounded)
            {
                if (_playerMoveInput.IsJump)
                    _vertSpeed = _jumpSpeed;
                else
                    _vertSpeed = 0;
            }
            else
                _vertSpeed += _gravity * Time.deltaTime;

            return new Vector3(movement.x, _vertSpeed * Time.deltaTime, movement.z);
        }
    }
}