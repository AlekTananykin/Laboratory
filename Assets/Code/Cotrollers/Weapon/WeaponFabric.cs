﻿using Assets.Code.Player;
using System;
using System.Collections.Generic;

namespace Lab
{
    sealed internal class WeaponFabric
    {
        Dictionary<string, IWeapon> _weaponStorage =
            new Dictionary<string, IWeapon>();

        public WeaponFabric()
        {
            _weaponStorage.Add("RayGun", new RayGun());
            _weaponStorage.Add("Grenades", new ThrowingGrenades());
        }

        public IWeapon CreateWeapon(string name)
        {
            if (!_weaponStorage.TryGetValue(name, out IWeapon weapon))
                throw new GameException(string.Format(
                    "WeaponFabric >> weapon {0} is not found. ", name));
            
            return weapon;
        }
    }
}