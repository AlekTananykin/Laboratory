using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lab;

namespace DangerouseItems
{
    public abstract class Bomb : 
        ViewHandle<BombModel>, IInitialization
    {
        public void Initialization(GameModel gameModel)
        {
            _model = gameModel.Bomb;
            transform.position = _model._position;
            this.gameObject.SetActive(_model.IsActive);
        }

        protected void Explosion(
            float hitRadius, float explosionForce, Collider bombCollider)
        {
            Collider[] colliders =
                Physics.OverlapSphere(this.transform.position, hitRadius);

            Vector3 explosionPosition = transform.position;
            foreach (Collider item in colliders)
            {
                if (bombCollider.Equals(item) ||
                    !item.TryGetComponent(out IReactToHit reaction))
                    continue;

                float distance =
                    (item.transform.position - explosionPosition).sqrMagnitude;

                reaction.ReactToHit((int)(explosionForce / (distance + 0.1f)));
            }

            Debug.Log("Explosion");
            OnDestroy();
        }
    }
}
