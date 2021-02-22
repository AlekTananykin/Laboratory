using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Player
{
    internal class PlayerActivitySystem
    {
        Dictionary<string, int> _backpack;
        IWeaponStorage _weaponStorage;

        public PlayerActivitySystem(IWeaponStorage weaponStorage)
        {
            _backpack = new Dictionary<string, int>();
            _weaponStorage = weaponStorage;
        }

        public void Use(Ray ray, Transform playerTransform)
        {
            const float maxDistance = 3f;
            if (!Physics.Raycast(ray, out RaycastHit hit, maxDistance))
                return;

            if (!IsAppropriatePosition(hit, playerTransform))
                return;

            GameObject item = hit.transform.gameObject;
            if (TryOperateDevice(item))
                return;

            if (TryPickUpUsefulItem(item))
                return;

            if (TryPickUpWeaponItem(item))
                return;
        }

        private bool TryPickUpWeaponItem(GameObject item)
        {
            if (!item.TryGetComponent(out IWeaponContainer weaponContainer))
                return false;

            _weaponStorage.AddWeapon(weaponContainer);
            return true;
        }

        bool IsAppropriatePosition(RaycastHit hit, Transform playerTransform)
        {
            if (Mathf.Abs(Vector3.Dot(hit.transform.forward.normalized,
                    playerTransform.forward.normalized)) > 0.5)
                return true;

            return false;
        }

        bool TryOperateDevice(GameObject item)
        {
            if (!item.TryGetComponent(out IDevice deviceController))
                return false;

            string termsOfUse = deviceController.GetTermsOfUse();
            if (_backpack.ContainsKey(termsOfUse))
            {
                int count = _backpack[termsOfUse];
                if (count > 0)
                {
                    --count;
                    if (0 == count)
                        _backpack.Remove(termsOfUse);
                }
                deviceController.Operate(termsOfUse);
            }
            else
                deviceController.Operate(string.Empty);

            return true;
        }

        bool TryPickUpUsefulItem(GameObject item)
        {
            if (!item.TryGetComponent(out IUsefulItem usefulItem))
                return false;

            usefulItem.PickUpItem(out string name, out int count);
            if (_backpack.ContainsKey(name))
                _backpack[name] += count;
            else
                _backpack.Add(name, count);

            return true;
        }
    }
}