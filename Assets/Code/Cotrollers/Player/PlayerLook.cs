using Assets.Code.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    public sealed class PlayerLook : MonoBehaviour
    {
        public float _sensHor = 9.0f;
        public float _sensVert = 9.0f;

        public float _minVert = -45.0f;
        public float _maxVert = 45.0f;
        public float _rotationX = 0;

        [SerializeField] private GameObject _player;

        IPlayerLookInput _playerLookInput;

        PlayerLook()
        {
            _playerLookInput = new PlayerMouseInput();
        }

        void Awake()
        {
            Rigidbody body = GetComponent<Rigidbody>();
            if (null != body)
                body.freezeRotation = true;

            _player = transform.parent.gameObject;
        }

        void Update()
        {
            if (0 == Time.timeScale)
                return;

            _rotationX -= _playerLookInput.MoveY * _sensVert;
            _rotationX = Mathf.Clamp(_rotationX, _minVert, _maxVert);

            transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
            float delta = _playerLookInput.MoveX * _sensHor;

            float rotationY = _player.transform.localEulerAngles.y + delta;
            _player.transform.localEulerAngles = new Vector3(0, rotationY, 0);
        }
    }
}