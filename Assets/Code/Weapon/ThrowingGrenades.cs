using Assets.Code.Player;
using System;
using System.Collections.Generic;
using System.IO;
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
            var myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "myassetBundle"));
            if (myLoadedAssetBundle == null)
            {
                Debug.Log("Failed to load AssetBundle!");
                return;
            }

            var prefab = myLoadedAssetBundle.LoadAsset<GameObject>("MyObject");
            GameObject.Instantiate(prefab);

            myLoadedAssetBundle.Unload(false);

            /*
            grenade.transform.position = ray.origin + ray.direction;

            Rigidbody bombRb = grenade.GetComponent<Rigidbody>();
            float force = 1f;
            bombRb.AddForce(ray.direction * force, ForceMode.Impulse);
            */
            Charge = 0;
        }

        public void Recharge()
        {
            Charge = 1;
        }

    }
}
