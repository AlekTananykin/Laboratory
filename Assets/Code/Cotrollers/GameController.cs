using Assets.Code.Cotrollers.SaveDataRepositiory;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    public sealed class GameController : MonoBehaviour
    {
        [SerializeField] private GameData _gameData;
        private GameModel _gameModel;

        InteractiveStorage _interactiveStorage;
        IPlayerInput _playerInput;

        SaveDataRepository<GameModel> _saveRepository;

        public GameController()
        {
            _interactiveStorage = new InteractiveStorage();
            _saveRepository = new SaveDataRepository<GameModel>();
        }

        void Start()
        {
            try
            {
                _gameModel = _gameData.CreateGameModel();
                _playerInput = new PlayerPcInput();
                
                new GameInitialization(
                    _interactiveStorage, _gameModel, _playerInput);

                _interactiveStorage.Initialization();
            }
            catch (GameException ge)
            {
                Debug.Log(ge.Data);
            }
        }

        void Update()
        {
            try
            {
                if (_playerInput.IsSaveGame)
                {
                    _saveRepository.Save(_gameModel);
                    Debug.Log("Game is saved. ");
                }
                else if (_playerInput.IsLoadLastSavedGame)
                {
                    ReloadGame();
                }

                _interactiveStorage.Execute(Time.deltaTime);
            }
            catch (GameException ge)
            {
                Debug.LogError(ge.Data);
            }
        }

        private void ReloadGame()
        {
            _interactiveStorage.Cleanup();
            _interactiveStorage.Clear();
            _saveRepository.Load(ref _gameModel);

            new GameInitialization(
                _interactiveStorage, _gameModel, _playerInput);

            _interactiveStorage.Initialization();
            Debug.Log("Game is reloaded. ");
        }

        void LateUpdate()
        {
            try
            {
                _interactiveStorage.LateExecute(Time.deltaTime);
            }
            catch (GameException ge)
            {
                Debug.LogError(ge.Data);
            }
        }

        void OnDestroy()
        {
            _interactiveStorage.Cleanup();
        }
    }
}
