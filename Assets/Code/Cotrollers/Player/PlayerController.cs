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

        public PlayerController(ICameraRay cameraRay, IPlayerInput playerInput)
        {
            _playerMoveSystem = new PlayerMoveSystem(playerInput);
            _playerLookSystem = new PlayerLookSystem(playerInput);

            _weaponSystem = new PlayerWeaponSystem();
            _activitySystem = new PlayerActivitySystem(_weaponSystem);
        }

        public (float rotationX, float deltaRotationY) Look()
        {
            _playerLookSystem.Look(out float rotationX, out float deltaRotationY);
            return (rotationX, deltaRotationY);
        }

        public Vector3 Move(bool isGrounded, float speed, float jumpSpeed)
        {
            return _playerMoveSystem.Move(isGrounded, speed, jumpSpeed);
        }
    }
}
