using Assets.Code.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Inventory
{
    public class ArmorBoxScript : UsefulItem
    {
        public ArmorBoxScript()
           : base("GunCartridges", 6)
        {
        }
    }
}
