using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Code.Player
{
    interface IPlayerOperateInput
    {
        bool UseWeapon { get; }
        bool UseDevice { get; }
    }
}
