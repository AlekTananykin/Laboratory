using Assets.Code.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerOperation : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _burst;

        enum Weapon { LaserRay, Mine, Granade };
        private Weapon _selectedWeapon = Weapon.LaserRay;

        Camera _camera;

        private IPlayerOperateInput _playerOperateInput;

        Dictionary<string, int> _backpack = new Dictionary<string, int>();

        PlayerOperation()
        {
            _playerOperateInput = new PlayerMouseInput();
        }

        public void Awake()
        {
            _camera = GameObject.FindGameObjectWithTag(
               "PlayerCamera").GetComponent<Camera>();
        }

        void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            if (0 == Time.timeScale)
                return;

            if (_playerOperateInput.UseWeapon)
            {
                UseWeapon();
            }
            else if (_playerOperateInput.UseDevice)
            {
                Use();
            }
        }

        Ray GetCameraRay()
        {
            Vector3 point = new Vector3(
                    _camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);

            return _camera.ScreenPointToRay(point);
        }

        void UseWeapon()
        {
            Ray ray = GetCameraRay();
            switch (_selectedWeapon)
            {
                case Weapon.LaserRay:
                    {
                        ShooteByRay(ray);
                        break;
                    }
            }
        }

        private void ShooteByRay(Ray ray)
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (!hit.collider.TryGetComponent(out IReactToHit target))
                    return;

                if (null != target)
                    target.ReactToHit(50);

                if (null == _burst)
                    return;

                _burst.transform.position = hit.point;

                _burst.transform.rotation = Quaternion.LookRotation(
                    transform.position - hit.point);
                _burst.Play();
            }
        }

        private void ToThrow(GameObject bomb, Ray ray, float force)
        {
            bomb.transform.position =
                transform.position + transform.forward;

            Rigidbody bombRb = bomb.GetComponent<Rigidbody>();
            bombRb.AddForce(ray.direction * force, ForceMode.Impulse);
        }

        void Use()
        {
            Ray ray = GetCameraRay();
            RaycastHit hit;
            const float maxDistance = 3f;
            if (Physics.Raycast(ray, out hit, maxDistance))
            {
                GameObject item = hit.transform.gameObject;
                Vector3 hitOrientation = item.transform.position - this.transform.position;
                if (Mathf.Abs(Vector3.Dot(hitOrientation.normalized,
                    transform.forward.normalized)) > 0.5f)
                {
                    if (item.TryGetComponent(out IDevice deviceController))
                    {
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
                    }
                    else if (item.TryGetComponent(out IUsefulItem usefulItem))
                    {
                        usefulItem.PickUpItem(out string name, out int count);
                        if (_backpack.ContainsKey(name))
                            _backpack[name] += count;
                        else
                            _backpack.Add(name, count);
                    }
                }
            }
        }
    }
}
