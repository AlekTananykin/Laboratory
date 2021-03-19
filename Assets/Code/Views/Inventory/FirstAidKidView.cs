using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    public class FirstAidKidView : UsefulItem
    {
        public FirstAidKidView()
            :base("FirstAidKid", 6)
        {
        }

        public override void Initialization(GameModel model)
        {
            _model = model.AidBoxModel;
            transform.position = _model._position;
            this.gameObject.SetActive(_model.IsActive);
        }
    }
}
