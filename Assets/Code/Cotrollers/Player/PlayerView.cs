using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Lab
{
    public sealed class PlayerView: MonoBehaviour, 
        IExecute, IInitialization, ILateExecute, ICameraRay, IReactToHit
    {
        private PlayerModel _model;
        PlayerController _playerController;

        private CharacterController _charecterController;
        private IPlayerInput _playerInput;

        private Camera _camera;

        private InformationScreenView _informationScreen;

        internal void SetModelAndInput(PlayerModel model, IPlayerInput playerInput)
        {
            _model = model;
            _playerInput = playerInput;
        }

        public void Initialization()
        {
            _camera = GameObject.FindGameObjectWithTag(
               "PlayerCamera").GetComponent<Camera>();

            _charecterController = GetComponent<CharacterController>();

            Rigidbody body = GetComponent<Rigidbody>();
            if (null != body)
                body.freezeRotation = true;

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            transform.position = _model._position;

            _playerController = new PlayerController(this, _playerInput);

            _informationScreen = new InformationScreenView();
            _informationScreen.Initialization();
            _informationScreen.Refresh(_model._health, _model._maxHealth);
        }

        public void Execute(float deltaTime)
        {
            if (0 == Time.timeScale)
                return;

            (float rotationX, float deltaRotationY) = 
                _playerController.Look();
            CameraTilt(rotationX);
            AngleOfRotation(deltaRotationY);

            Vector3 movement = _playerController.Move(
                _charecterController.isGrounded, _model._speed, _model._jumpSpeed);
            
            _charecterController.Move(transform.TransformDirection(movement));
        }

        public void LateExecute(float deltaTime)
        {
            if (_model._health <= 0)
                Debug.Log("You is dead. ");
        }

        public Ray GetCameraRay()
        {
            Vector3 point = new Vector3(
                    _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

            return _camera.ScreenPointToRay(point);
        }

        public void CameraTilt(float tilt)
        {
            _camera.transform.localEulerAngles = new Vector3(tilt, 0, 0);
        }

        public void AngleOfRotation(float rotationDelta)
        {
            float rotationY = transform.localEulerAngles.y + rotationDelta;
            transform.localEulerAngles = new Vector3(0, rotationY, 0);
        }

        public void ReactToHit(int hitCount)
        {
            _model._health -= hitCount;
            if (_model._health < 0)
                _model._health = 0;

            _informationScreen.Refresh(_model._health, _model._maxHealth);
        }

    }
}
