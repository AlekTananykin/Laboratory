using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

namespace Lab
{
    internal sealed class PlayerWeaponSystem : IWeaponStorage
    {
        private IWeapon _selectedWeapon = null;
        private WeaponFabric _weaponFabric = new WeaponFabric();

        Dictionary<string, IWeapon> _weapons =
            new Dictionary<string, IWeapon>();
        Dictionary<string, int> _catridges =
            new Dictionary<string, int>();

        List<IWeapon> _weaponList = new List<IWeapon>();

        public void ApplyByRay(Ray ray)
        {
            if (null == _selectedWeapon)
                return;

            _selectedWeapon.Apply(ray);
        }

        public void SelectNextWeapon(float direction)
        {
            if (0 == direction || 0 == _weapons.Count)
                return;

            int delta = 1;
            if (direction < 0)
                delta = -1;

            int weaponIndex = _weaponList.IndexOf(_selectedWeapon) + delta;
            _selectedWeapon =
                _weaponList[weaponIndex % _weaponList.Count];
        }

        public void SelectWeapon(int number)
        {
            if (_weapons.Count <= number || number < 0)
                return;

            _selectedWeapon = _weaponList[number];
        }

        public void SelectWeapon(string name)
        {
            if (!_weapons.ContainsKey(name))
                return;

            _selectedWeapon = _weapons[name];
        }

        public void Recharge()
        {
            if (_catridges.TryGetValue(
                _selectedWeapon.Name, out int bulletsCount))
            {
                _selectedWeapon.Recharge();
                _catridges[_selectedWeapon.Name]--;
            }
        }

        public void AddWeapon(string name)
        {
            if (!_weapons.ContainsKey(name))
            {
                IWeapon weapon = _weaponFabric.CreateWeapon(name);
                _weapons.Add(name, weapon);
                _weaponList.Add(weapon);
            }
        }

        public void AddCartridges(string name, int count)
        {
            if (_catridges.ContainsKey(name))
                _catridges[name] += count;
            else
                _catridges.Add(name, count);
        }

        public void DiscardWeapon(string name)
        {
            if (_weapons.TryGetValue(name, out IWeapon weapon))
            {
                if (_weapons.Count > 1)
                    SelectNextWeapon(1.0f);
                else
                    _selectedWeapon = null;

                _weaponList.Remove(weapon);
                _weapons.Remove(name);
            }
        }

        public void DiscardCartridges(string name)
        {
            if (_catridges.ContainsKey(name))
                _catridges.Remove(name);
        }

        public List<string> GetWeaponsList()
        {
            return _weapons.Keys.ToList();
        }

        public int GetSelectedWeaponCharge()
        {
            return _selectedWeapon.Charge;
        }

        public int GetSelectedWeaponCartridgesCount()
        {
            if (_catridges.TryGetValue(_selectedWeapon.Name, out int count))
                return count;

            return 0;
        }

        public void AddWeapon(IWeaponContainer weaponContainer)
        {
            if (weaponContainer.IsWeapon)
                AddWeapon(weaponContainer.Name);
            else
                AddCartridges(weaponContainer.Name, weaponContainer.Count);
        }
    }
}