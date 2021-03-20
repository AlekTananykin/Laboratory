using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Lab
{
    public sealed class RayGun : IWeapon
    {
        private const int _maxCharrgeSize = 10;
        public string Name => "RayGun";

        public int Charge { get; private set; }

        public void Apply(Ray ray)
        {
            if (0 == Charge)
                return;
            --Charge;

            if (!Physics.Raycast(ray, out RaycastHit hit))
                return;

            if (!hit.collider.TryGetComponent(out IReactToHit target))
                return;

            if (null != target)
                target.ReactToHit(50);
        }

        public void Recharge()
        {
            Charge = _maxCharrgeSize;
        }
    }
}
