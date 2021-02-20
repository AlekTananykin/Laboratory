using Assets.Code.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Inventory
{
    public abstract class UsefulItem : MonoBehaviour, IUsefulItem, IReactToHit
    {
        protected const int _isNotUtilized = -1;

        private readonly string _name;
        private readonly int _count;
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
    }
}
