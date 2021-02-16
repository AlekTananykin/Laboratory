using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Player
{
    interface IUsefulItem
    {
        string PickUpItem(out string name, out int count);
    }
}