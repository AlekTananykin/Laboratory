using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Lab
{
    [CreateAssetMenu(fileName = "GameData", menuName = "GameData/GameData")]
    public sealed class GameData : ScriptableObject
    {
        [SerializeField] private string _playerModelPath;
        [SerializeField] private string _enemyDataPath;
        [SerializeField] private string _supplyDataPath;

        private PlayerModel _player;
        public PlayerModel Player
        {
            get
            {
                if (null == _player)
                {
                    _player = Load<PlayerModel>("GameData/" + _playerModelPath);
                }
                return _player;
            }
        }

        private SupplyModel _supplyModel;
        public SupplyModel Supply
        {
            get 
            {
                if (null == _supplyModel)
                {
                    _supplyModel = Load<SupplyModel>("GameData/" + _supplyDataPath);
                }
                return _supplyModel;
            }
        }


        private T Load<T>(string resourcePath) where T: Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcePath, null));
    }
}
