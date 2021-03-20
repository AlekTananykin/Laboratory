using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Lab
{
    public sealed class PlayerController
    {
        private PlayerMoveSystem _playerMoveSystem;
        private PlayerLookSystem _playerLookSystem;

        private PlayerWeaponSystem _weaponSystem;
        private PlayerActivitySystem _activitySystem;

        ICameraRay _cameraRay;
        IPlayerInput _playerInput;

        public PlayerController(ICameraRay cameraRay, IPlayerInput playerInput)
        {
            _playerMoveSystem = new PlayerMoveSystem();
            _playerLookSystem = new PlayerLookSystem();

            _weaponSystem = new PlayerWeaponSystem();
            _activitySystem = new PlayerActivitySystem(_weaponSystem);

            _cameraRay = cameraRay;
            _playerInput = playerInput;
        }

        public (float rotationX, float deltaRotationY) Look()
        {
            return _playerLookSystem.Look(_playerInput);
        }

        public Vector3 Move(bool isGrounded, float speed, float jumpSpeed)
        {
            return _playerMoveSystem.Move(
                isGrounded, speed, jumpSpeed, _playerInput);
        }

        public void Use(Transform transform)
        {
            if (_playerInput.UseDevice)
                _activitySystem.Use(_cameraRay, transform);
        }
    }
}
