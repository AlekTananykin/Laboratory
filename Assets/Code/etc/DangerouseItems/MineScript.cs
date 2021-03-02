using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DangerouseItems
{
    public class MineScript : Bomb, IDevice, IReactToHit
    {
        private const string _termsOfUse = "SupplyKid";
        private const float _hitRadius = 5f;
        private const float _explosionForce = 10f;

        Collider _collider;
        void Awake()
        {
            _collider = this.GetComponent<Collider>();
        }

        public string GetTermsOfUse()
        {
            return _termsOfUse;
        }

        public string Operate(string key)
        {
            if (_termsOfUse == key)
            {
                Destroy(this.gameObject);
                return "Mine has been deactivated. ";
            }

            Explosion(_hitRadius, _explosionForce, _collider);
            return "Mine has been explosed. ";
        }

       

        public void ReactToHit(int hitCount)
        {
            if (hitCount <= 1)
                return;

            Explosion(_hitRadius, _explosionForce, _collider);
        }


        private void OnTriggerExit(Collider other)
        {
            Debug.Log(other.gameObject.name);
            if (!other.gameObject.TryGetComponent(
               out IReactToHit reactToHit))
                return;

            Explosion(_hitRadius, _explosionForce, _collider);
        }

    }
}
