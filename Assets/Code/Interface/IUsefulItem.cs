using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    interface IUsefulItem
    {
        void PickUpItem(out string name, out int count);
    }
}