using Assets.Code.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    internal sealed class PlayerMoveSystem
    {
        private const float _gravity = -9.8f;
        

        private float _vertSpeed = 0;

        public PlayerMoveSystem()
        {
            _vertSpeed = 0;
        }

        public Vector3 Move(bool isGrounded, float speed, 
            float jumpSpeed, IPlayerInput playerInput)
        {
            float deltaX = playerInput.HorizontalMove * speed;
            float deltaZ = playerInput.VerticalMove * speed;
            Vector3 movement = new Vector3(deltaX, 0, deltaZ);
            movement = Vector3.ClampMagnitude(movement, speed);
            movement *= Time.deltaTime;

            movement = ProcessVerticalMove(
                movement, jumpSpeed, isGrounded, playerInput);

            return movement;

        }

        private Vector3 ProcessVerticalMove(Vector3 movement, 
            float jumpSpeed, bool isGrounded, IPlayerInput playerInput)
        {
            if (isGrounded)
            {
                if (playerInput.IsJump)
                    _vertSpeed = jumpSpeed;
                else
                    _vertSpeed = 0;
            }
            else
                _vertSpeed += _gravity * Time.deltaTime;

            return new Vector3(movement.x, 
                _vertSpeed * Time.deltaTime, movement.z);
        }
    }
}