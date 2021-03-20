using Assets.Code.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    public class ProximityCard : UsefulItem, IExecute
    {
        Vector3 _rotation = new Vector3();
        
        public ProximityCard()
            :base("GlassDoorKey", _isNotUtilized)
        {
        }

        public void Execute(float deltaTime)
        {
            _rotation = _rotation +
               new Vector3(0.01f, 0.02f, 0.03f) * Time.deltaTime;

            this.transform.Rotate(_rotation);
        }
    }
}
