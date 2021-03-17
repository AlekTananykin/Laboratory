using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Lab
{
    public sealed class GameModel
    {
        public PlayerModel Player {get;set;}
        public SupplyModel SupplyBox {get; set;}
        public SupplyModel AmmoBox {get;set;}
        public SupplyModel AidBoxModel {get;set;}
        public SupplyModel ProximityCardModel { get; set; }
        public BombModel Bomb { get; set; }
    }
}
