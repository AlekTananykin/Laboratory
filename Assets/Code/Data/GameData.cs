﻿using System.Collections;
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

        private SupplyModel _supplyBoxModel;
        public SupplyModel SupplyBox
        {
            get 
            {
                if (null == _supplyBoxModel)
                {
                    _supplyBoxModel = Load<SupplyModel>("GameData/" + _supplyDataPath);
                }
                return _supplyBoxModel;
            }
        }

        private SupplyModel _ammoBoxModel;
        public SupplyModel AmmoBox
        {
            get
            {
                if (null == _ammoBoxModel)
                {
                    _ammoBoxModel = Load<SupplyModel>("GameData/" + _ammoDataPath);
                }
                return _ammoBoxModel;
            }
        }

        private SupplyModel _aidBoxModel;
        public SupplyModel AidBoxModel
        {
            get
            {
                if (null == _aidBoxModel)
                {
                    _aidBoxModel = Load<SupplyModel>("GameData/" + _aidDataPath);
                }
                return _aidBoxModel;
            }
        }


        private T Load<T>(string resourcePath) where T: Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcePath, null));
    }
}
