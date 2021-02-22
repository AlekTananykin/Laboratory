using Assets.Code.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Code.Weapon
{
    class ThrowingGrenades : IWeapon
    {
        public string Name => "Grenades";

        public int Charge { get; private set; }

        public void Apply(Ray ray)
        {
            //GameObject bomb = GameObject.Instantiate(Resources.Load("enemy", typeof(GameObject))) as GameObject;

            //bomb.transform.position = ray.origin + ray.direction;

            //Rigidbody bombRb = bomb.GetComponent<Rigidbody>();
            //float force = 1f;
            //bombRb.AddForce(ray.direction * force, ForceMode.Impulse);
            Charge = 0;
        }

        public void Recharge()
        {
            Charge = 1;
        }

    }
}
