using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DangerouseItems
{
    public class GrenadeScript : Bomb, Lab.IReactToHit
    {
        private float _explosionDelay = 3f;
        
        private const float _hitRadius = 5f;
        private const float _explosionForce = 10f;

        private bool _isActivated;

        private Collider _collider;
        void Awake()
        {
            _isActivated = false;
            _collider = this.GetComponent<Collider>();
        }

        public void ReactToHit(int hitCount)
        {
            if (hitCount <= 1)
                return;

            Explosion(_hitRadius, _explosionForce, _collider);
        }

        void Update()
        {
            if (!_isActivated)
                return;

            _explosionDelay -= Time.deltaTime;
            if (_explosionDelay > 0)
                return;

            Explosion(_hitRadius, _explosionForce, _collider);
        }

        void Activate()
        {
            _isActivated = true;
        }
    }
}
