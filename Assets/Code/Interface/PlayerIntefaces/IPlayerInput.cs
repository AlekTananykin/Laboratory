using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Lab
{
    public interface IPlayerInput : IInitialization
    {
        float MoveX { get; }
        float MoveY { get; }
        
        float HorizontalMove { get; }
        float VerticalMove { get; }

        bool IsJump { get; }

        bool UseWeapon { get; }
        bool UseDevice { get; }
        float SelectWeapon { get; }

        bool IsSaveGame { get; }

    }
}
