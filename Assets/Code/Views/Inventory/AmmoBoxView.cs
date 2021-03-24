using Assets.Code.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab
{
    public sealed class AmmoBoxView : UsefulItem
    {
        public AmmoBoxView()
           : base("GunCartridges", 6)
        {
        }

        public override void Initialization(GameModel model)
        {
            _model = model.AmmoBox;
            transform.position = _model._position;
            this.gameObject.SetActive(_model.IsActive);
        }
    }
}
