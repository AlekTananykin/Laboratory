using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Lab
{
    [CreateAssetMenu(fileName = "Data", menuName = "Data/Data")]
    public sealed class Data : ScriptableObject
    {
        [SerializeField] private string _playerDataPath;
        [SerializeField] private string _enemyDataPath;

        private PlayerData _player;
        public PlayerData Player
        {
            get
            {
                if (null == _player)
                {
                    _player = Load<PlayerData>("Data/" + _playerDataPath);
                }

                return _player;
            }
        }



        private T Load<T>(string resourcePath) where T: Object =>
            Resources.Load<T>(Path.ChangeExtension(resourcePath, null));
    }
}
