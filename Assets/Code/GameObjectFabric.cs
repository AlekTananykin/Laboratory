﻿using System;
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


    }
}
