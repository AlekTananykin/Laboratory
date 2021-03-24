using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Lab
{
    [CreateAssetMenu(fileName ="Supply",
        menuName= "GameData/Models/Supply")]
    public sealed class SupplyData: ScriptableObject
    {
        public Vector3 _position;
    }
}
