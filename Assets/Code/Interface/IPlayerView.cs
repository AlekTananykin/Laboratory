using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Lab
{
    interface IPlayerView: ICameraRay
    {
        bool IsGrounded { get; }

        Vector3 Position{get; set;}

        void CameraTilt(float tilt);

        void AngleOfRotation(float rotationDelta);
    }
}
