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

        GameController()
        {
            _interactiveStorage = new InteractiveStorage();
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
                _interactiveStorage.Execute(Time.deltaTime);
            }
            catch (GameException ge)
            {
                Debug.LogError(ge.Data);
            }
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
