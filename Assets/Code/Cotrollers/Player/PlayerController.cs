using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Code.Player;
using UnityEngine;

namespace Lab
{
    public class PlayerController : IReactToHit
    {
        private IPlayerOperateInput _playerOperateInput;
        private PlayerWeaponSystem _weaponSystem;
        private PlayerActivitySystem _activitySystem;
        private PlayerMoveSystem _playerMoveSystem;
        private ICameraRay _raySource;

        internal PlayerController(ICameraRay raySource)
        {
            _playerOperateInput = new PlayerMouseInput();
            _weaponSystem = new PlayerWeaponSystem();
            _activitySystem = new PlayerActivitySystem(_weaponSystem);
            _playerMoveSystem = new PlayerMoveSystem();
            _raySource = raySource;
        }

        public void ReactToHit(int hitCount)
        {
            //Health = Mathf.Clamp(Health -
              //  Mathf.Abs(hitCount), 0, MaxHealth);
        }

        internal void Execute(float deltaTime)
        {
            //_weaponSystem.SelectNextWeapon(_playerOperateInput.SelectWeapon);
            //if (_playerOperateInput.UseWeapon)
            //{
            //    _weaponSystem.ApplyByRay(_raySource.GetCameraRay());
            //}
            //if (_playerOperateInput.UseDevice)
            //{
            //    //_activitySystem.Use(_raySource.GetCameraRay(), transform);
            //}
        }

    }
}