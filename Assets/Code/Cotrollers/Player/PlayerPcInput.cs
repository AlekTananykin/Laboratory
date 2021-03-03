using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Lab
{
    sealed class PlayerPcInput: IPlayerInput
    {
        public float MoveX => Input.GetAxis("Mouse X");

        public float MoveY => Input.GetAxis("Mouse Y");


        public bool UseWeapon => Input.GetMouseButtonDown(0);

        public bool UseDevice => Input.GetMouseButtonDown(1);

        public float SelectWeapon => Input.mouseScrollDelta.y;


        public float HorizontalMove => Input.GetAxis("Horizontal");
        public float VerticalMove => Input.GetAxis("Vertical");

        public bool IsJump => Input.GetButton("Jump");

        public void Initialization()
        {
            Debug.Log("Input is initialized. ");
        }
    }
}
