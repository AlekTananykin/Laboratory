using Assets.Code.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    internal sealed class PlayerLookSystem
    {
        public float _sensHor = 9.0f;
        public float _sensVert = 9.0f;

        public float _minVert = -45.0f;
        public float _maxVert = 45.0f;
        public float _rotationX = 0;

        IPlayerInput _playerLookInput;

        public PlayerLookSystem(IPlayerInput plauerInput)
        {
            _playerLookInput = plauerInput;
        }

        public void Look(out float rotationX, out float deltaRotationY)
        {
            _rotationX -= _playerLookInput.MoveY * _sensVert;
            _rotationX = Mathf.Clamp(_rotationX, _minVert, _maxVert);
            rotationX = _rotationX;
            deltaRotationY = _playerLookInput.MoveX * _sensHor;
        }
    }
}