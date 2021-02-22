using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Player
{
    public interface IWeapon
    {
        string Name { get; }
        int Charge { get; }

        void Recharge();
        void Apply(Ray ray);

    }
}
