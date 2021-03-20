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

        public (float rotationX, float deltaRotationY) Look(IPlayerInput plauerInput)
        {
            _rotationX -= plauerInput.MoveY * _sensVert;
            _rotationX = Mathf.Clamp(_rotationX, _minVert, _maxVert);
            return (_rotationX, plauerInput.MoveX * _sensHor);
        }
    }
}