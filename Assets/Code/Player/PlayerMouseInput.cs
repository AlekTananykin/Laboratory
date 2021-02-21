using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Player
{
    sealed class PlayerMouseInput: IPlayerLookInput, IPlayerOperateInput
    {
        public float MoveX => Input.GetAxis("Mouse X");

        public float MoveY => Input.GetAxis("Mouse Y");

        public bool UseWeapon => Input.GetMouseButtonDown(0);

        public bool UseDevice => Input.GetMouseButtonDown(1);


    }
}
