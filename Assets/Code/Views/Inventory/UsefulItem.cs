using UnityEngine;

namespace Lab
{
    public abstract class UsefulItem : MonoBehaviour, IInitialization, IUsefulItem, IReactToHit
    {
        protected const int _isNotUtilized = -1;

        private readonly string _name;
        private readonly int _count;

        private SupplyModel _model;
        public UsefulItem(string name, int count)
        {
            _name = name;
            _count = count;
        }

        public void PickUpItem(out string name, out int count)
        {
            name = _name;
            count = _count;
            Destroy(this.gameObject);
        }

        public void ReactToHit(int hitCount)
        {
            if (hitCount <= 1)
                return;

            Destroy(this.gameObject);
        }

        public void SetModel(SupplyModel model)
        {
            _model = model;
        }

        public void Initialization()
        {
            transform.position = _model._position;
        }
    }
}
