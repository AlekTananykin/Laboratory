using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    public class SupplyKidView : UsefulItem
    {
        public SupplyKidView()
            :base("SupplyKid", 6)
        {
        }

        public override void Initialization(GameModel model)
        {
            _model = model.SupplyBox;
            transform.position = _model._position;
            this.gameObject.SetActive(_model.IsActive);
        }
    }
}