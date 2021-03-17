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
        GameData _gameData;

        public GameSaver(IPlayerInput playerInput, GameData gameData)
        {
            _playerInput = playerInput;
            _gameData = gameData;
        }

        public void Execute(float deltaTime)
        {
            if (!_playerInput.IsSaveGame)
                return;

            var s = new SaveDataRepository<GameData>();
            s.Save(_gameData);

            Debug.Log("Game is saved. ");
        }
    }
}
