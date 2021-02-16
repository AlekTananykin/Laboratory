using Assets.Code.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Player
{
    public sealed class PlayerMove : MonoBehaviour
    {

        public const float _speed = 10.0f;
        private const float _gravity = -9.8f;
        [SerializeField] private float _jumpSpeed = 12f;

        private float _vertSpeed = 0;

        private CharacterController _charController;

        private IPlayerMoveInput _playerMoveInput;

        PlayerMove()
        {
            _playerMoveInput = new PlayerKeyboardInput();
        }


        void Start()
        {
            _charController = GetComponent<CharacterController>();
            _vertSpeed = 0;
        }

        // Update is called once per frame
        void Update()
        {
            float deltaX = _playerMoveInput.HorizontalMove * _speed;
            float deltaZ = _playerMoveInput.VerticalMove * _speed;
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, _speed);
            movement *= Time.deltaTime;

            movement = ProcessVerticalMove(movement);
            movement = transform.TransformDirection(movement);
            _charController.Move(movement);
        }

        private Vector3 ProcessVerticalMove(Vector3 movement)
        {
            if (_charController.isGrounded)
            {
                if (Input.GetButton("Jump"))
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