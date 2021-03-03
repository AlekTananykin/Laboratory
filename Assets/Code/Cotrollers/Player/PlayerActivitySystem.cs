using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    internal class PlayerActivitySystem
    {
        public delegate void ActivityMessages(string msg);
        public event ActivityMessages PlayerActivityMessages;

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
            //if (!item.TryGetComponent(out IWeaponContainer weaponContainer))
            //    return false;

            //_weaponStorage.AddWeapon(weaponContainer);

            //if (null != PlayerActivityMessages)
            //{
            //    string message;
            //    if (weaponContainer.IsWeapon)
            //        message = string.Format(
            //            "You have picked up {0}. ", weaponContainer.Name);
            //    else
            //        message = string.Format(
            //            "You have picked up bullets for {0}. ", weaponContainer.Name);

            //    PlayerActivityMessages.Invoke(message);
            //}
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
            string operationMessage;
            if (_backpack.ContainsKey(termsOfUse))
            {
                int count = _backpack[termsOfUse];
                if (count > 0)
                {
                    --count;
                    if (0 == count)
                        _backpack.Remove(termsOfUse);
                }
                operationMessage = deviceController.Operate(termsOfUse);
            }
            else
                operationMessage = deviceController.Operate(string.Empty);

            PlayerActivityMessages?.Invoke(operationMessage);

            return true;
        }

        bool TryPickUpUsefulItem(GameObject item)
        {
            //if (!item.TryGetComponent(out IUsefulItem usefulItem))
            //    return false;

            //usefulItem.PickUpItem(out string name, out int count);
            //if (_backpack.ContainsKey(name))
            //    _backpack[name] += count;
            //else
            //    _backpack.Add(name, count);

            //PlayerActivityMessages?.Invoke(string.Format(
            //    "You have picked up {0}. ", name));
            return true;
        }
    }
}