﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerController : MonoBehaviour, IReactToHit
    {
        private Camera _camera;

        private IPlayerOperateInput _playerOperateInput;
        private PlayerWeaponSystem _weaponSystem;
        private PlayerOperationSystem _operationSystem;

        public int Health { get; private set; }
        private int _maxHealth;
        public int MaxHealth
        {
            get
            {
                return _maxHealth;
            }
            set
            {
                _maxHealth = Mathf.Abs(value);
            }
        }

        PlayerController()
        {
            Health = 100;
            MaxHealth = 100;

            _playerOperateInput = new PlayerMouseInput();
            _weaponSystem = new PlayerWeaponSystem();
            _operationSystem = new PlayerOperationSystem(_weaponSystem);
        }

        public void Awake()
        {
            _camera = GameObject.FindGameObjectWithTag(
               "PlayerCamera").GetComponent<Camera>();
        }

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        public void ReactToHit(int hitCount)
        {
            Health = Mathf.Clamp(Health -
                Mathf.Abs(hitCount), 0, MaxHealth);

            Debug.Log("Player Health " + Health.ToString());
        }

        void Update()
        {
            if (0 == Time.timeScale)
                return;

            if (_playerOperateInput.UseWeapon)
            {
                _weaponSystem.ApplyByRay(GetCameraRay());
            }
            else if (_playerOperateInput.UseDevice)
            {
                _operationSystem.Use(GetCameraRay(), transform);
            }
        }

        Ray GetCameraRay()
        {
            Vector3 point = new Vector3(
                    _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

            return _camera.ScreenPointToRay(point);
        }
    }
}