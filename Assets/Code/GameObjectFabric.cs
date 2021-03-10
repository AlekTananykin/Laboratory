using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Lab
{
    public sealed class GameObjectFabric
    {
        GameObject _player;
        public GameObject GetPlayer()
        {
            if (null == _player)
            {
                GameObject prefab = (GameObject)Resources.Load("Prefabs\\Player");
                if (null == prefab)
                    throw new GameException();
                _player = GameObject.Instantiate(prefab);
            }
            return _player;
        }

        private GameObject _supplyBoxPrefab;
        public GameObject GetSupplyBox()
        {
            return CreateObjectFromFile(ref _supplyBoxPrefab, 
                "Prefabs\\Boxes\\box_supply");
        }

        private GameObject _ammoBoxPrefab;
        public GameObject GetAmmoBox()
        {
            return CreateObjectFromFile(ref _ammoBoxPrefab, 
                "Prefabs\\Boxes\\box_ammo");
        }

        private GameObject _aidKidBoxPrefab;
        public GameObject GetAidKidBox()
        {
            return CreateObjectFromFile(ref _aidKidBoxPrefab,
                "Prefabs\\Boxes\\box_med");
        }

        GameObject CreateObjectFromFile(ref GameObject prefab, string prefabPath)
        {
            if (null == prefab)
            {
                prefab = (GameObject)Resources.Load(prefabPath);
                if (null == prefab)
                    throw new GameException("CreateObjectFromFile: " +
                        "Prefab can't be loaded from file \"" + prefabPath + "\"");
            }
            return GameObject.Instantiate(prefab);
        }

    }
}
