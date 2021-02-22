using Assets.Code.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerOperationSystem
    {

        Dictionary<string, int> _backpack;
        IWeaponStorage _weaponStorage;

        public PlayerOperationSystem(IWeaponStorage weaponStorage)
        {
            _backpack = new Dictionary<string, int>();
            _weaponStorage = weaponStorage;
        }

        public void Use(Ray ray, Transform playerTransform)
        {
            RaycastHit hit;
            const float maxDistance = 3f;
            if (!Physics.Raycast(ray, out hit, maxDistance))
                return;

            GameObject item = hit.transform.gameObject;
            if (!IsAppropriatePosition(item, playerTransform))
                return;

            if (TryOperateDevice(item))
                return;

            if (TryPickUpUsefulItem(item))
                return;

            if (TryGetWeaponItem(item))
                return;
        }

        private bool TryGetWeaponItem(GameObject item)
        {
            if (!item.TryGetComponent(out IWeaponContainer deviceController))
                return false;

            _weaponStorage.AddWeapon(deviceController);
            return true;
        }

        bool IsAppropriatePosition(GameObject item, Transform playerTransform)
        {
            Vector3 hitOrientation = item.transform.position - playerTransform.position;
            if (Mathf.Abs(Vector3.Dot(hitOrientation.normalized,
                playerTransform.forward.normalized)) > 0.5f)
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
