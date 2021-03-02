using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Player
{
    sealed class PlayerKeyboardInput : IPlayerMoveInput
    {
        public float HorizontalMove => Input.GetAxis("Horizontal");
        public float VerticalMove => Input.GetAxis("Vertical");
    }
}
