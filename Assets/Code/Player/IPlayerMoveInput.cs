using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Player
{
    interface IPlayerMoveInput
    {
        float HorizontalMove { get; }
        float VerticalMove { get; }
    }
}
