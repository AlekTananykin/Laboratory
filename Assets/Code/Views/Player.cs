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
        private PlayerController _controller;

        private GameObject _playerView;
        private IPlayerView _playerViewHandler;
    
        public Player(PlayerModel model)
        {
            _model = model;
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

            _controller.Execute(Time.deltaTime);
        }
    }
}
