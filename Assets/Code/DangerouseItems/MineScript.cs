using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace DangerouseItems
{
    public class MineScript : MonoBehaviour, IDevice, IReactToHit
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

            Explosion();
            return "Mine has been explosed. ";
        }

        private void Explosion()
        {
            Collider[] colliders =
                Physics.OverlapSphere(this.transform.position, _hitRadius);

            Vector3 explosionPosition = transform.position;
            foreach (Collider item in colliders)
            {
                if (_collider.Equals(item) ||
                    !item.TryGetComponent(out IReactToHit hittedItem))
                    continue;

                float ditance = 
                    (item.transform.position - explosionPosition).sqrMagnitude;
                if (item.TryGetComponent(out IReactToHit reaction))
                {
                    reaction.ReactToHit((int)(_explosionForce / (ditance + 0.1f)));
                }
            }

            Debug.Log("Explosion");
            Destroy(this.gameObject);
        }

        public void ReactToHit(int hitCount)
        {
            if (hitCount <= 1)
                return;

            Explosion();
        }


        private void OnTriggerExit(Collider other)
        {
            Debug.Log(other.gameObject.name);
            if (!other.gameObject.TryGetComponent(
               out IReactToHit reactToHit))
                return;

            Explosion();
        }

    }
}
