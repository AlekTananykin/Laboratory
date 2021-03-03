using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    interface IPlayerOperateInput
    {
        bool UseWeapon { get; }
        bool UseDevice { get; }
        float SelectWeapon { get; }
    }
}
