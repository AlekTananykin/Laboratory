using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Player
{
    enum ItemType { 
        Weapon = 0, 
        Tool = 1, 
        WeaponCartridge = 2
    };

    

    interface IUsefulItem
    {
        
        void PickUpItem(out ItemType type, out string name, out int count);
    }
}