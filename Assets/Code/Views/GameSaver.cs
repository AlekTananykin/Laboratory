using Assets.Code.Cotrollers.SaveDataRepositiory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Lab
{
    public sealed class GameSaver: IExecute
    {
        IPlayerInput _playerInput;
        GameModel _gameModel;
        SaveDataRepository<GameModel> _saveRepository;

        public GameSaver(IPlayerInput playerInput, GameModel gameModel)
        {
            _playerInput = playerInput;
            _gameModel = gameModel;
            _saveRepository = new SaveDataRepository<GameModel>();
        }

        public void Execute(float deltaTime)
        {
            if (_playerInput.IsSaveGame)
            {
                _saveRepository.Save(_gameModel);

                Debug.Log("Game is saved. ");
            }
            else if (_playerInput.IsLoadLastSavedGame)
            {
                _saveRepository.Load(ref _gameModel);
                Debug.Log("Game is reloaded. ");
            }
        }
    }
}
