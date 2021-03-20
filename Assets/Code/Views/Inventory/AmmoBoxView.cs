using Assets.Code.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    public sealed class AmmoBoxView : UsefulItem
    {
        public AmmoBoxView()
           : base("GunCartridges", 6)
        {
        }
    }
}
