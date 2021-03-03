using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Lab
{
    interface IPlayerMoveInput
    {
        float HorizontalMove { get; }
        float VerticalMove { get; }

        bool IsJump { get; }
    }
}
