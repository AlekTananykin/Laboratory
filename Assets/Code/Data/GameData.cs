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
        [SerializeField] private string _ammoDataPath;
        [SerializeField] private string _aidDataPath;
        [SerializeField] private string _proximityCardDataPath;
        [SerializeField] private string _bombDataPath;

        public GameModel CreateGameModel()
        {
            return new GameModel()
            { 
                Player = Player, 
                SupplyBox = SupplyBox, 
                AmmoBox = AmmoBox,
                AidBoxModel = AidBoxModel,
                ProximityCardModel  = ProximityCardModel,
                Bomb = Bomb
            };
        }

        private PlayerData _playerData;
        private PlayerModel Player
        {
            get
            {
                if (null == _playerData)
                {
                    _playerData = Load<PlayerData>(
                        "GameData/" + _playerModelPath);
                }
                return new PlayerModel() 
                {
                    _health = _playerData._health,
                    _maxHealth = _playerData._maxHealth,
                    _speed = _playerData._speed,
                    _jumpSpeed = _playerData._jumpSpeed,
                    _position = _playerData._position
                };
            }
        }

        private SupplyData _supplyBoxData;
        private SupplyModel SupplyBox
        {
            get 
            {
                if (null == _supplyBoxData)
                {
                    _supplyBoxData = Load<SupplyData>(
                        "GameData/" + _supplyDataPath);
                }
                return new SupplyModel()
                {
                    _position = _supplyBoxData._position
                };
            }
        }

        private SupplyData _ammoBoxData;
        private SupplyModel AmmoBox
        {
            get
            {
                if (null == _ammoBoxData)
                {
                    _ammoBoxData = Load<SupplyData>(
                        "GameData/" + _ammoDataPath);
                }
                return new SupplyModel()
                {
                    _position = _ammoBoxData._position
                };
            }
        }

        private SupplyData _aidBoxData;
        private SupplyModel AidBoxModel
        {
            get
            {
                if (null == _aidBoxData)
                {
                    _aidBoxData = Load<SupplyData>(
                        "GameData/" + _aidDataPath);
                }
                return new SupplyModel()
                {
                    _position = _aidBoxData._position
                };
            }
        }

        private SupplyData _proximityCardData;
        private SupplyModel ProximityCardModel
        {
            get
            {
                if (null == _proximityCardData)
                {
                    _proximityCardData = Load<SupplyData>(
                        "GameData/" + _proximityCardDataPath);
                }
                return new SupplyModel()
                {
                    _position = _proximityCardData._position
                };
            }
        }

        private BombData _bombData;
        private BombModel Bomb
        {
            get
            {
                if (null == _bombData)
                {
                    _bombData = Load<BombData>("GameData/" + _bombDataPath);
                }
                return new BombModel() 
                {
                    _position = _bombData._position
                };
            }
        }

        private T Load<T>(string resourcePath) where T: Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcePath, null));
    }
}
