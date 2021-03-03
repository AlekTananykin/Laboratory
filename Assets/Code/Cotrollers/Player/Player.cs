using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Lab
{
    public sealed class Player: 
        IExecute, IInitialization
    {
        private PlayerModel _model;

        private GameObject _playerView;
        private IPlayerView _playerViewHandler;

        private PlayerMoveSystem _playerMoveSystem;
        private PlayerLookSystem _playerLookSystem;

        PlayerWeaponSystem _weaponSystem;
        PlayerActivitySystem _activitySystem;

        public Player(PlayerModel model, IPlayerInput playerInput)
        {
            _model = model;

            _playerMoveSystem = new PlayerMoveSystem(playerInput);
            _playerLookSystem = new PlayerLookSystem(playerInput);

            _weaponSystem = new PlayerWeaponSystem();
            _activitySystem = new PlayerActivitySystem(_weaponSystem);
        }

        public void Initialization()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            _playerView = GameObject.Instantiate(_model._playerPrefab);
            _playerView.transform.position = _model._position;
            _playerViewHandler = _playerView.GetComponent<IPlayerView>();
        }

        public void Execute(float deltaTime)
        {
            if (0 == Time.timeScale)
                return;

            _playerLookSystem.Look(out float rotationX, out float deltaRotationY);
            _playerViewHandler.CameraTilt(rotationX);
            _playerViewHandler.AngleOfRotation(deltaRotationY);

            Vector3 movement = _playerMoveSystem.Move(
                _playerViewHandler.IsGrounded, _model._speed, _model._jumpSpeed);
            _playerViewHandler.Position = 
                _playerView.transform.TransformDirection(movement);
            
            

        }



    }
}
